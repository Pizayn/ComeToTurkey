import { Injectable } from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Message } from 'app/_models/message';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';
import { Blog } from 'app/_models/blog';
import { AdminService } from 'app/_services/admin.service';
import { News } from 'app/_models/news';

@Injectable()
export class NewsDetailResolver implements Resolve<News> {
  
    constructor(private adminService: AdminService, private authService: AuthService,
                private router: Router, private aletfify: AlertifyService) { }
    resolve(route: ActivatedRouteSnapshot): Observable<News> {
        return this.adminService.getNews(
                route.params['id']).pipe(
            catchError(error => {
                this.aletfify.error('Problems retrieving comments');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}