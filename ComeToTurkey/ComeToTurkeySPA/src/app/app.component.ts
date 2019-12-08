import { Component,OnInit} from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  helper=new JwtHelperService();


  constructor(private authService:AuthService){}
  ngOnInit(){
    const token=localStorage.getItem('token');
    const user=JSON.parse(localStorage.getItem('user'))
    if(token){
      this.authService.decodedToken=this.helper.decodeToken(token);
    }
    if(user){
      this.authService.user=user;
      this.authService.changeMemberPhoto(user.photoUrl)

    }

  }


}
