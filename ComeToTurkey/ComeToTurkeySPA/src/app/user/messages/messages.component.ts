import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'app/_services/alertify.service';
import { AuthService } from 'app/_services/auth.service';
import { Message } from 'app/_models/message';
import { PaginationResult, Pagination } from 'app/_models/pagination';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
  messages: Message[];
  pagination: Pagination;
  messageContainer="Outbox";
  constructor(private userService: UserService, private authService: AuthService,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      // tslint:disable-next-line:no-string-literal
      this.messages = data['messages'].result;
      // tslint:disable-next-line:no-string-literal
      this.pagination = data['messages'].pagination;
    });
  }
  loadMessages() {
    this.userService.getMessages(this.authService.decodedToken.nameid, this.pagination.currentPage,
          this.pagination.itemsPerPage, this.messageContainer)
          .subscribe( (res: PaginationResult<Message[]>) => {
              this.messages = res.result;
              this.pagination = res.pagination;
          }, error => {
            this.alertify.error(error);
          });
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadMessages();
  }
  
  
 
  deleteMessage(id: number) {
    this.alertify.confirm('Are you sure you want to delete this message?', () => {
      this.userService.deleteMessage(id, this.authService.decodedToken.nameid).subscribe( () => {
        this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
        this.alertify.success('Message has been deleted');
      }, error => {
        this.alertify.error('Failed to delete the message');
      });
    });
  }

} 
