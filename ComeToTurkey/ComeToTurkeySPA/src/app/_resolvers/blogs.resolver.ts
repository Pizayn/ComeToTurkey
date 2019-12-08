import { Injectable } from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Message } from 'app/_models/message';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';
import { Blog } from 'app/_models/blog';

@Injectable()
export class BlogsResolver implements Resolve<Blog[]> {
    pageNumber = 1;
    pageSize = 5;
    blogParams:any={};
  
  
    constructor(private userService: UserService, private authService: AuthService,
                private router: Router, private aletfify: AlertifyService) { }
    resolve(route: ActivatedRouteSnapshot): Observable<Blog[]> {
       this.blogParams.blogCategoryId=route.queryParams['blogCategoryId']
      
        return this.userService.getBlogs(this.authService.decodedToken.nameid, this.pageNumber,
                this.pageSize,this.blogParams).pipe(
            catchError(error => {
                this.aletfify.error('Problems retrieving comments');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}