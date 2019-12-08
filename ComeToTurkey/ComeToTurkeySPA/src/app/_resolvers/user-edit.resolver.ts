import { Injectable } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/user';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';


@Injectable()
export class UserEditResolver implements Resolve<User> {
    constructor(private userService: UserService, private router: Router, private aletfify: AlertifyService,
                private authService: AuthService ) { }
    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.userService.getUser(this.authService.decodedToken.nameid)
           
    }
}