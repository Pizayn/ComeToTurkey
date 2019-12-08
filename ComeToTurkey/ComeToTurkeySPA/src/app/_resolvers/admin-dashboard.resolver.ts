import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AdminService } from "app/_services/admin.service";
import { AdminDashboard } from "app/_models/admin/admindashboard";
@Injectable()
export class AdminDashboardResolver implements Resolve<AdminDashboard>{
    constructor(private adminService: AdminService, private router:Router
        , private alertify: AlertifyService){}


        resolve(route: ActivatedRouteSnapshot) : Observable<AdminDashboard> {
            return this.adminService.getDashBoard().pipe(
                catchError(error=>{
                    this.alertify.error('Problem retrieving data');
                    this.router.navigate(['/admin']);
                    return of(null);
                })
            );
        }
 
        
}