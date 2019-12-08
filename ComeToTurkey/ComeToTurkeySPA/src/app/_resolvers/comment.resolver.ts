import { Injectable } from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Message } from 'app/_models/message';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';

@Injectable()
export class CommentResolver implements Resolve<Comment[]> {
    pageNumber = 1;
    pageSize = 3;
    constructor(private userService: UserService, private authService: AuthService,
                private router: Router, private aletfify: AlertifyService) { }
    resolve(route: ActivatedRouteSnapshot): Observable<Comment[]> {
        return this.userService.getComments(this.authService.decodedToken.nameid, this.pageNumber,
                this.pageSize,route.params['id']).pipe(
            catchError(error => {
                this.aletfify.error('Problems retrieving comments');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}