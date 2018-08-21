import { Component, OnInit, EventEmitter } from '@angular/core';
import { SelectItem } from 'primeng/primeng';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';

import { ChatHub } from '../core/hubs/chat.hub';
import { AuthService } from '../core/services/auth.service';
import { ChatService } from '../core/services/chat.service';
import { ToastrService } from '../core/services/toastr.service';

import { Chat } from '../shared/models/chat.model';
import { Message } from '../shared/models/message.model';
import { User } from '../shared/models/user.model';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.sass']
})
export class ChatComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private chatHub: ChatHub,
    private authService: AuthService,
    private chatService: ChatService,
    private toastrService: ToastrService) { }


  public onDisplayChat = new EventEmitter<Chat>();
  public onDisplayChatCreating = new EventEmitter<boolean>();

  chatList: SelectItem[] = [];
  selectedChat: Chat;
  currentUser: User;

  ngOnInit() {

    this.currentUser = this.authService.getCurrentUser();
    this.chatService.getByUserId(this.currentUser.id).subscribe(
      chats => {
        chats.reverse();
        chats.forEach(chat => {
          this.chatList.push({ value: chat });
        });
        this.subscribeToEvents();
      },
      err => {
        this.toastrService.error('Can`t get user`s chats');
      }
    );
  }

  openChat() {
    this.onDisplayChat.emit(this.selectedChat);
  }

  openChatCreating() {
    this.onDisplayChatCreating.emit();
  }

  subscribeToEvents() {
    this.chatHub.chatCreated.subscribe((chat: Chat) => {
      this.chatList.unshift({ value: chat });
      this.selectedChat = chat;
      this.openChat();
    });

    this.chatHub.messageReceived.subscribe((message: Message) => {
      if (this.selectedChat && this.selectedChat.id === message.chatId) {
        this.selectedChat.messages.push(message);
      }
    });

    this.chatHub.chatChanged.subscribe((chat: Chat) => {
      const index = this.chatList.findIndex(x => x.value.id === chat.id);
      this.chatList.splice(index, 1, { value: chat });
    });
  }
}
