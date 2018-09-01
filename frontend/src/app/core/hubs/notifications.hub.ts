import { EventEmitter, Injectable } from '@angular/core';

import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../../environments/environment';
import { AuthService } from '../services/auth.service';
import { Notification } from '../../shared/models/notification.model';
import { NotificationType } from '../../shared/models/notification-type.enum';

@Injectable({
  providedIn: 'root'
})
export class NotificationsHubService {
  private hubConnection: HubConnection | undefined;

  notificationReceived = new EventEmitter<Notification>();
  notificationDeleted = new EventEmitter<number>();

  connectionEstablished = new EventEmitter<Boolean>();

  constructor(private authService: AuthService) {
    this.startNotificationsHubConnection();
  }

  private createConnection(): void {
    const firebaseToken = this.authService.getFirebaseToken();
    const watcherToken = this.authService.getWatcherToken();
    const connPath = `${environment.server_url}/notifications?Authorization=${firebaseToken}&WatcherAuthorization=${watcherToken}`;

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(connPath) // {accessTokenFactory: () => firebaseToken}
      .configureLogging(signalR.LogLevel.Information)
      .build();
  }

  private startNotificationsHubConnection(): void {
    this.createConnection();
    console.log('NotificationsHub trying to connect');
    this.hubConnection.start()
      .then(() => {
        console.log('NotificationsHub connected');
        this.registerOnServerEvents();
      })
      .catch(err => {
        console.error('Error while establishing connection (NotificationsHub)');
        setTimeout(this.startNotificationsHubConnection(), 3000);
      });
  }

  send(notification: Notification, type: NotificationType) {
    if (this.hubConnection) {
      this.hubConnection.invoke('SendNotification', notification, type)
        .catch(err => console.error(err));
    }
  }

  delete(notification: Notification) {
    if (this.hubConnection) {
      this.hubConnection.invoke('DeleteNotification', notification)
        .catch(err => console.error(err));
    }
  }

  private registerOnServerEvents(): void {
    this.hubConnection.on('AddNotification', (data: Notification) => {
      console.log('Notification added');
      this.notificationReceived.emit(data);
    });

    this.hubConnection.on('DeleteNotification', (data: number) => {
      console.log('Notification deleted');
      this.notificationDeleted.emit(data);
    });

    this.hubConnection.onclose(err => {
      console.log('NotificationsHub connection closed');
      console.error(err);
      this.startNotificationsHubConnection();
    });
  }
}
