import { Component, OnInit } from '@angular/core';
import { AuthService } from 'app/_services/auth.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { User } from 'app/_models/user';
import { AlertifyService } from 'app/_services/alertify.service';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
user:User;
public loginForm:FormGroup;
model:any={};
  constructor(public dialogRef: MatDialogRef<LoginComponent> ,private authService:AuthService,private fb:FormBuilder,private alertify:AlertifyService) { }

  ngOnInit() {
    this.createForm();
  }
  createForm(){
    this.loginForm=this.fb.group(
      {
        username:['',Validators.required],
        password:['',Validators.required]
      }
      )

  }
  login(){
    if(this.loginForm.valid)
    {
      this.user=Object.assign({},this.loginForm.value)
      this.authService.login(this.user).subscribe(data=>{
        this.alertify.success('login success');
        this.dialogRef.close();
        
  
      },error=>{
        this.alertify.error('Invalid request')
      })
    }
   
  }


}
