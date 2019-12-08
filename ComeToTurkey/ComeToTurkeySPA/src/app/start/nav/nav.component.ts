import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { RegisterComponent } from 'app/account/register/register.component';
import { LoginComponent } from 'app/account/login/login.component';
import { AuthService } from 'app/_services/auth.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { Router } from '@angular/router';
import { User } from 'app/_models/user';
import { UserService } from 'app/_services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
users:User[];
  constructor(public dialog:MatDialog,private authService:AuthService,private alertify:AlertifyService,private router:Router,private userService:UserService) { }
  ngOnInit() {
    this.userService.getUsers().subscribe(data=>{
      this.users=data;
    })
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(RegisterComponent, {
    
     
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  openLoginDialog(): void {
    const dialogRef = this.dialog.open(LoginComponent, {
      width:'450px',
      height:'650px',
     
     
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  loggedIn()
  {
    return this.authService.loggedIn();
  }
  logOut()
  {
    localStorage.clear();
    this.alertify.success("logged out");
    this.authService.decodedToken=null;
    this.authService.user=null;
    this.router.navigate(['main']);

  }
  

}
