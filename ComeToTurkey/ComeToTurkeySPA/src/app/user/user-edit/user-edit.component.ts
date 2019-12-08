import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'app/_models/user';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {
 @ViewChild('editForm',{static: false}) editForm: NgForm;
user:User;
photoUrl:string;
@HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any){
    if(this.editForm.dirty){
      $event.returnValue = true;
    }
  }
  constructor(private route:ActivatedRoute,private userService:UserService,private authService : AuthService,
    private alertify:AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(x=>{
      this.user=x['user'];
      this.authService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);

    });
  }
  updateUser() {
    this.userService.updateUser(this.authService.decodedToken.nameid,this.user).subscribe(next=>{
      this.alertify.success('Profile updated succesfully');
      this.editForm.reset(this.user);
  

    },error=>{
      this.alertify.error(error)
    });
  


  }
  changeEditPhoto(photoUrl) {
    this.user.photoUrl = photoUrl;
  }
 

}
