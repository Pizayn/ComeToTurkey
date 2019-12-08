import { Injectable } from '@angular/core';
import {Resolve, Router} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Message } from 'app/_models/message';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';

@Injectable()
export class MessagesResolver implements Resolve<Message[]> {
    pageNumber = 1;
    pageSize = 5;
    messageContainer = 'Unread';
    constructor(private userService: UserService, private authService: AuthService,
                private router: Router, private aletfify: AlertifyService) { }
    resolve(): Observable<Message[]> {
        return this.userService.getMessages(this.authService.decodedToken.nameid, this.pageNumber,
                this.pageSize, this.messageContainer).pipe(
            catchError(error => {
                this.aletfify.error('Problems retrieving messages');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}