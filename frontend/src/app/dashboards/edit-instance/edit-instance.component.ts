import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { ToastrService } from '../../core/services/toastr.service';
import { InstanceService } from '../../core/services/instance.service';
import { AuthService } from '../../core/services/auth.service';
import { Instance } from '../../shared/models/instance.model';
import { InstanceRequest } from '../models/instance-request.model';
import { SelectItem } from '../../../../node_modules/primeng/api';

@Component({
  selector: 'app-edit-instance',
  templateUrl: './edit-instance.component.html',
  styleUrls: ['./edit-instance.component.sass']
})
export class EditInstanceComponent implements OnInit {

  id: number;
  organizationId: number;
  instanceForm: FormGroup;
  instance: Instance;
  instanceTitle: string;
  platformsDropdown: SelectItem[];
  selectedPlatform: string;
  isSaving: Boolean = false;

  constructor(private activateRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastrService: ToastrService,
    private instanceService: InstanceService,
    private authService: AuthService,
    private router: Router) {
    this.platformsDropdown = [];
  }

  ngOnInit() {
    const x = this.activateRoute.params.subscribe(params => {
      this.id = params['insId'];
      if (this.id) {
        this.instanceService.getOne(this.id).subscribe((data: Instance) => {
          if (data) {
            this.instance = data;
            console.log(this.instance.guidId);
            this.instanceForm = this.getInstanceForm(this.instance);
          }
        });
      }
    });
    const user = this.authService.getCurrentUser();
    if (user == null || user.lastPickedOrganizationId == null) {
      this.toastrService.error('User must taking part in organization');
      return;
    } else {
      this.organizationId = user.lastPickedOrganization.id;
    }
    this.instanceForm = this.getInstanceForm(this.instance);
    this.fillDropdown();
    this.instanceForm.controls['platform'].setValue(this.platformsDropdown[0].value);
  }

  getInstanceForm(instance: Instance) {
    let form: FormGroup;

    if (instance) {
      form = this.fb.group({
        title: new FormControl({ value: instance.title, disabled: false }, Validators.required),
        platform: new FormControl({ value: instance.platform, disabled: false }, Validators.required),
        address: new FormControl({ value: instance.address, disabled: false }), // , Validators.required
        guid: new FormControl({ value: instance.guidId, disabled: false })
      });
      this.instanceTitle = 'EDIT INSTANCE';

    } else {
      form = this.fb.group({
        title: new FormControl({ value: '', disabled: false }, Validators.required),
        platform: new FormControl({ value: '', disabled: false }, Validators.required),
        address: new FormControl({ value: '', disabled: false }), // , Validators.required
        guid: new FormControl({ value: '', disabled: false })
      });
      this.instanceTitle = 'NEW INSTANCE';
    }
    return form;
  }

  onSubmit() {
    if (this.instanceForm.valid) {
      this.isSaving = true;
      const request: InstanceRequest = this.getNewInstance();
      if (this.id) {
        request.guidId = this.instance.guidId;
        this.instanceService.update(request, this.id).subscribe((res: Response) => {
          this.toastrService.success('updated instance');

          const updatedInstance: Instance = {
            title: request.title,
            address: request.address,
            id: this.id,
            platform: request.platform,
            guidId: request.guidId,
            isActive: true,
            dashboards: this.instance.dashboards,
            organization: this.instance.organization
          };

          this.instanceService.instanceEdited.emit(updatedInstance);
          this.router.navigate([`/user/instances/${updatedInstance.id}/${this.instance.guidId}/dashboards`]);
          this.isSaving = false;
        });
      } else {
        this.instanceService.create(request).subscribe((res: Instance) => {
          this.toastrService.success('created instance');
          this.instanceService.instanceAdded.emit(res);
          this.router.navigate([`/user/instances/${res.id}/${res.guidId}/dashboards`]);
          this.isSaving = false;
        });
      }
    } else {
      this.toastrService.error('Invalid form');
      this.isSaving = false;
    }
  }

  getNewInstance() {
    const newInstance: InstanceRequest = {
      title: this.instanceForm.controls.title.value,
      address: this.instanceForm.controls.address.value,
      platform: this.instanceForm.controls.platform.value,
      isActive: true,
      organizationId: this.organizationId
    };
    return newInstance;
  }

  private fillDropdown(): void {
    this.platformsDropdown.push(
      { label: 'Windows', value: 'Windows' },
      { label: 'Linux', value: 'Linux' });
  }

  copyToClipboard(message: string): void {
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = message;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    document.body.removeChild(selBox);
    this.toastrService.info(`Copied to clipboard`);
  }
}
