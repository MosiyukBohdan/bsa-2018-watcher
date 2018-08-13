import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/primeng';
import { SampleDto } from '../../shared/models/sample-dto.model';
import { MessageService } from 'primeng/api';
import { DashboardService } from '../../core/services/dashboard.service';
import { Dashboard } from '../../shared/models/dashboard.model';
import { Instance } from '../../shared/models/instance.model';
import { ToastrService } from '../../core/services/toastr.service';
import { DashboardMenuItem } from '../models/dashboard-menuitem.model';
import { NotificationsService } from '../../core/services/notifications.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass'],
  providers: [ToastrService, ConfirmationService, DashboardService, MessageService]
})

export class DashboardComponent implements OnInit {

  instance: Instance;

  dashboardMenuitems: DashboardMenuItem[];
  activeDashboardItem: DashboardMenuItem;

  editTitle: string;
  creation: boolean;
  loading = false;
  displayEditDashboard = false;

  constructor(private dashboardsService: DashboardService, private toastrService: ToastrService,
    private notificationsService: NotificationsService,
    private messageService: MessageService) {
    this.activeDashboardItem = {};
    this.dashboardMenuitems = [];
    this.instance = { id: 1, address: 'adress', platform: 'platform' };
    this.subscribeToEvents();
  }

  transformToDashboard(dashboard: DashboardMenuItem): Dashboard {
    const newdash: Dashboard = {
      title: dashboard.label,
      createdAt: dashboard.createdAt,
      id: dashboard.dashId,
      instance: dashboard.instance,
      charts: dashboard.charts,
    };
    return newdash;
  }

  transformToMenuItem(dashboard: Dashboard): DashboardMenuItem {
    const item: DashboardMenuItem = {
      label: dashboard.title,
      dashId: dashboard.id,
      instance: dashboard.instance,
      createdAt: dashboard.createdAt,
      charts: dashboard.charts,
      command: (onclick) => { this.activeDashboardItem = item; }
    };
    return item;
  }

  createDashboard(newDashboard: Dashboard) {
    this.dashboardsService.create(newDashboard)
      .subscribe(
        (res: Response) => {
          console.log(res);
          const item: DashboardMenuItem = this.transformToMenuItem(newDashboard);
          this.dashboardMenuitems.splice(this.dashboardMenuitems.length - 1, 0, item);
          this.loading = false;
          this.toastrService.success('Added new dashboard');
        },
        error => {
          this.loading = false;
          this.toastrService.error(`Error ocured status: ${error}`);
        });
  }

  updateDashboard(editTitle: string) {
    const index = this.dashboardMenuitems.findIndex(d => d === this.activeDashboardItem);
    const payload: Dashboard = this.transformToDashboard(this.dashboardMenuitems[index]);
    payload.title = editTitle;

    this.dashboardsService.update(payload)
      .subscribe(
        (res: Response) => {
          console.log(res);
          this.dashboardMenuitems[index].label = payload.title;
          this.loading = false;
          this.toastrService.success('Updated dashboard');
        },
        error => {
          this.loading = false;
          this.toastrService.success(`Error ocured status: ${error}`);
        });
  }

  deleteDashboard(dashboard: DashboardMenuItem) {
    this.dashboardsService.delete(dashboard.dashId)
      .subscribe((res: Response) => {
        console.log(res);
        const index = this.dashboardMenuitems.findIndex(d => d === this.activeDashboardItem);
        this.dashboardMenuitems.splice(index, 1);

        if (this.dashboardMenuitems.length >= 1) {
          this.activeDashboardItem = this.dashboardMenuitems[0];
        } else {
          this.activeDashboardItem = null;
        }

        this.loading = false;
        this.toastrService.success('Deleted dashboard');
      },
        error => {
          this.loading = false;
          this.toastrService.error(`Error occured status: ${error}`);
        });
  }

  async delete() {
    if (await this.toastrService.confirm('You sure you want to delete dashboard ?')) {
      this.loading = true;
      this.deleteDashboard(this.activeDashboardItem);
    }
  }

  configureDashboards() {
    this.dashboardsService.getAllByInstance(this.instance.id).subscribe(
      (data: Dashboard[]) => {
        if (data) {
          this.dashboardMenuitems = data.map(
            dash => this.transformToMenuItem(dash));
          this.loading = false;
          this.toastrService.success('Succesfully got info from server');
        }
      },
      error => {
        this.loading = false;
        this.toastrService.error(`Error occured status: ${error}`);
      });
  }

  showCreatePopup(creation: boolean) {
    this.creation = creation;
    // if we are adding new textbox needs to be clear
    this.editTitle = creation ? '' : this.activeDashboardItem.label;
    this.displayEditDashboard = true;
  }

  onEdited(title: string) {
    this.loading = true;
    if (this.creation === true) {
      const newdash: Dashboard = {id: 123, title: title, createdAt: new Date(), instance: this.instance, charts: null };
      this.createDashboard(newdash);
      let index = 0;
      // switching to new tab
      if (this.dashboardMenuitems.length >= 2) {
        index = this.dashboardMenuitems.length - 2;
        this.activeDashboardItem = this.dashboardMenuitems[index];
      }
    } else {
      this.updateDashboard(title);
    }
    this.creation = false;
    this.displayEditDashboard = false;
  }

  onClosed() {
    if (this.creation === true) {
      if (this.dashboardMenuitems.length >= 2) {
        // switching to last dashboard if popup is closed without save
        const index = this.dashboardMenuitems.length - 2;
        const label = this.dashboardMenuitems[index].label.slice();

        // TODO: refactor this shit below
        const x: DashboardMenuItem = {
          label: label,
          dashId: this.dashboardMenuitems[index].dashId,
          createdAt: this.dashboardMenuitems[index].createdAt,
          instance: this.dashboardMenuitems[index].instance,
          charts: this.dashboardMenuitems[index].charts,
          command: this.dashboardMenuitems[index].command
        };

        this.dashboardMenuitems[index] = x;
        this.activeDashboardItem = this.dashboardMenuitems[index];
      }
    }
    this.creation = false;
    this.displayEditDashboard = false;
  }

  private subscribeToEvents(): void {
    this.notificationsService.connectionEstablished.subscribe(() => {
      console.log('Connected from dashboard');
    });

    this.notificationsService.sampleReceived.subscribe((sample: SampleDto) => {
      this.messageService.add({
        severity: 'info', summary: sample.name, detail: `Name: ${sample.name}, Id: ${sample.id},
          Sample Field: ${sample.sampleField.toString()}, Date of creation: ${sample.dateOfCreation}, Count: ${sample.count}, `
      });
    });
  }

  ngOnInit() {
    this.loading = true;
    this.configureDashboards();

    const lastItem: DashboardMenuItem = {
      label: 'Add new',
      icon: 'fa fa-plus',
      command: (onlick) => {
        this.showCreatePopup(true);
      },
      id: 'lastTab'
    };

    this.dashboardMenuitems.push(lastItem);
    this.activeDashboardItem = this.dashboardMenuitems[0];
  }
}
