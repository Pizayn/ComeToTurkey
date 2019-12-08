import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from './alertify.service';
import { from, BehaviorSubject } from 'rxjs';
import { User } from 'app/_models/user';
import { environment } from 'environments/environment';
import { map } from 'rxjs/operators';

import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseuRL=environment.apiUrl+ 'auth/';
user:User;
name:any='safasf'
helper=new JwtHelperService();
decodedToken:any
photoUrl = new BehaviorSubject<string>('../../assets/img/user.png');
currentPhotoUrl = this.photoUrl.asObservable();

constructor(private http:HttpClient,private alertify:AlertifyService) { }

changeMemberPhoto(photoUrl: string ) {
  this.photoUrl.next(photoUrl);
}
register(user:User){
 return this.http.post(this.baseuRL+'register',user);

}
login(userr:User){
 return this.http.post(this.baseuRL+'login',userr).pipe(map((response:any)=>{
    const user=response
    if(user){
      localStorage.setItem('token',user.token);
      localStorage.setItem('user',JSON.stringify(user));
      this.user=user.user;
      this.decodedToken=this.helper.decodeToken(user.token);
      this.changeMemberPhoto(this.user.photoUrl);



    }
  }));

}
loggedIn()
{
  const token=localStorage.getItem('token');
  return !this.helper.isTokenExpired(token);
}

}
