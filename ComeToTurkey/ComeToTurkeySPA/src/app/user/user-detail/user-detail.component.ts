import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { from } from 'rxjs';
import { TabsetComponent } from '../../../../node_modules/ngx-bootstrap';
import { User } from 'app/_models/user';
import { UserService } from 'app/_services/user.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { AuthService } from 'app/_services/auth.service';
import { error } from '@angular/compiler/src/util';
import { Follow } from 'app/_models/follow';
import { Jsonp } from '@angular/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {
  user: User;
  followers:Follow[];

  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  sayi:number=0;
  @ViewChild('memberTabs', {static: true}) memberTabs: TabsetComponent;
  constructor(private userService: UserService,private authService:AuthService, private alertify: AlertifyService, private route: ActivatedRoute
   ) { }

  ngOnInit() {
    this.route.data.subscribe(data=>{
      this.user=data['user'];
      this.followers=this.user.followers;
      this.sayi=this.authService.decodedToken.nameid
      
     
    });
 
    this.galleryOptions = [
     {
       width: '500px',
       height: '500px',
       imagePercent : 100,
       thumbnailsColumns: 4,
       imageAnimation: NgxGalleryAnimation.Slide,
       preview: false
     }
   ];
   this.galleryImages=this.getImages();
 
  }
  
  getImages() {
    const imageUrls = [];
    // tslint:disable-next-line:whitespace
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < this.user.photos.length; i++) {
      imageUrls.push({
        small: this.user.photos[i].url,
        medium: this.user.photos[i].url,
        big: this.user.photos[i].url,
      });
    }
    return imageUrls;
  }
  selectTab(tabId: number) {
    this.memberTabs.tabs[tabId].active = true;
}
sendFollows(id:number){
  this.userService.sendFollow(this.authService.decodedToken.nameid,id).subscribe(data=>{
    this.alertify.success("you have follows" + this.user.firstName);
   const follow=new Follow();
   follow.followerId=this.authService.decodedToken.nameid;
   this.followers.push(follow);
       
 
   
  })
  

}
sendUnFollows(id:number){
  this.userService.sendUnFollow(this.authService.decodedToken.nameid,id).subscribe(data=>{
    this.alertify.success("you have Unfollow" + this.user.firstName);
    this.followers.splice(this.user.followers.findIndex(p => p.followerId ===  this.authService.decodedToken.nameid), 1);
  })
  

}
isFollowExist()
{
  if(this.followers.find(p => p.followerId ==  this.authService.decodedToken.nameid) ){
    return true;
  }
  if(this.followers.find(p => p.followerId !=  this.authService.decodedToken.nameid) ){
    return false;
  }
 
 
 
 
 

   

  

}

}
