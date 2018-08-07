import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsComponent } from './settings.component';
import { NotificationSettingsComponent } from './notification-settings/notification-settings.component';
import { RouterModule } from '../../../node_modules/@angular/router';
import { TabViewModule, PanelMenuModule } from 'primeng/primeng';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { SettingsRoutingModule } from './settings-routing.module';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    TabViewModule,
    PanelMenuModule,
    SettingsRoutingModule
  ],
  declarations: [ SettingsComponent, NotificationSettingsComponent, UserProfileComponent]
})
export class SettingsModule { }
