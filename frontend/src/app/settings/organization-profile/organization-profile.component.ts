import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormBuilder, Validators } from '@angular/forms';
import { OrganizationService } from '../../core/services/organization.service';
import { ToastrService } from '../../core/services/toastr.service';
import { AuthService } from '../../core/services/auth.service';
import { Organization } from '../../shared/models/organization.model';
import { usesServiceWorker } from '../../../../node_modules/@angular-devkit/build-angular/src/angular-cli-files/utilities/service-worker';
import { OrganizationInvitesService } from '../../core/services/organization-ivites.service';
import { OrganizationInvite } from '../../shared/models/organization-invite.model';
import { OrganizationInviteState } from '../../shared/models/organization-invite-state.enum';
import { environment } from '../../../environments/environment';
import { ImageCropperComponent, CropperSettings } from 'ngx-img-cropper';
import { User } from '../../shared/models/user.model';

@Component({
  selector: 'app-organization-profile',
  templateUrl: './organization-profile.component.html',
  styleUrls: ['./organization-profile.component.sass'],
  providers: [
    ToastrService, OrganizationService, OrganizationInvitesService
  ]
})
export class OrganizationProfileComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private organizationService: OrganizationService,
    private organizationInvitesService: OrganizationInvitesService,
    private authService: AuthService,
    private toastrService: ToastrService) {
      this.cropperSettings = new CropperSettings();
      this.cropperSettings.width = 200;
      this.cropperSettings.height = 200;
      this.cropperSettings.minWidth = 100;
      this.cropperSettings.minHeight = 100;
      this.cropperSettings.croppedWidth = 70;
      this.cropperSettings.croppedHeight = 70;
      this.cropperSettings.canvasWidth = 400;
      this.cropperSettings.canvasHeight = 400;
      this.cropperSettings.noFileInput = true;
      this.cropperSettings.preserveSize = true;
      this.data = {};
    }

  editable: boolean;
  organization: Organization;

  inviteLink = '';
  inviteEmail: string;
  invite: OrganizationInvite;

  @ViewChild('cropper', undefined)
  cropper: ImageCropperComponent;
  cropperSettings: CropperSettings;
  display: Boolean = false;
  imageUrl = '';
  data: any;

  user: User;

  private phoneRegex = /\(?([0-9]{3})\)?[ .-]?[0-9]*$/;
  private urlRegex = /[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}/;

  organizationForm = this.fb.group({
    name: new FormControl({ value: '', disabled: true }, Validators.required),
    email: new FormControl({ value: '', disabled: true }, Validators.email),
    contactNumber: new FormControl({ value: '', disabled: true }, Validators.pattern(this.phoneRegex)),
    webSite: new FormControl({ value: '', disabled: true }, Validators.pattern(this.urlRegex)),
    description: new FormControl({ value: '', disabled: true })
  });

  ngOnInit() {
    this.authService.currentUser.subscribe(
      (userData) => {
        this.user = { ...userData };
        this.organization = this.user.lastPickedOrganization;
        this.subscribeOrganizationFormToData();
        if (this.organization.createdByUserId === this.user.id) {
          this.editable = true;
        }
      });

    Object.keys(this.organizationForm.controls).forEach(field => {
      const control = this.organizationForm.get(field);
      control.enable();
    });
  }

  subscribeOrganizationFormToData() {
    Object.keys(this.organizationForm.controls).forEach(field => {
      const control = this.organizationForm.get(field);
      control.setValue(this.organization[field]);
      control.valueChanges.subscribe(value => {
        this.organization[field] = value;
      });
    });
  }

  onSubmit() {
    if (this.organizationForm.valid && this.editable) {
      this.organizationService.update(this.organization.id, this.organization).subscribe(
        value => {
          const user = this.authService.getCurrentUser();
          user.lastPickedOrganization = this.organization;
          this.toastrService.success('Organization was updated');
        },
        err => {
          this.toastrService.error('Organization was not updated');
        }
      );
    } else {
      this.toastrService.error('Form was filled incorrectly');

      Object.keys(this.organizationForm.controls).forEach(field => {
        const control = this.organizationForm.get(field);
        control.markAsDirty({ onlySelf: true });
      });
    }
  }

  onInvite() {
    const invite: OrganizationInvite = {
      id: 0,
      organizationId: this.organization.id,
      createdByUserId: this.authService.getCurrentUser().id,
      inviteEmail: null,
      invitedUserId: null,
      createdByUser: null,
      organization: null,
      createdDate: null,
      experationDate: null,
      link: null,
      state: OrganizationInviteState.Pending
    };

    this.organizationInvitesService.create(invite).subscribe(
      value => {
        this.toastrService.success('Organization Invite was created');
        this.invite = value;
        this.inviteLink = `${environment.client_url}/user/invite/${value.link}`;
      },
      err => {
        this.toastrService.error('Organization Invite was not created');
      });
  }

  onSentInviteToEmail() {
    if (this.inviteEmail === null) { return; }
    this.invite.inviteEmail = this.inviteEmail;
    this.organizationInvitesService.update(this.invite.id, this.invite).subscribe(
    value => {
      this.toastrService.success('Organization Invite was updated and sends to email.');
    },
    err => {
      this.toastrService.error('Organization Invite was not updated');
    });
  }

  onCopy() {
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = this.inviteLink;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    document.body.removeChild(selBox);
  }

  onImageSelected(upload) {
    const image: any = new Image();
    const reader: FileReader = new FileReader();
    const that = this;
    reader.onloadend = (eventLoad: any) => {
      image.src = eventLoad.target.result;
      that.cropper.setImage(image);
      this.display = true;
    };

    reader.readAsDataURL(upload[0]);
    upload.splice(0, upload.length);
  }

  onCropCancel() {
    this.display = false;
  }

  onCropSave() {
    this.organization.imageURL = this.data.image;
    this.imageUrl = this.data.image;
    this.display = false;
  }
}
