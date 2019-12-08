import { Component, OnInit } from '@angular/core';
import { AuthService } from 'app/_services/auth.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { User } from 'app/_models/user';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  user:User;
  public registerForm:FormGroup;
  bsconfig:Partial<BsDatepickerConfig>;
  model:any={};
  myName:string

  constructor(public dialogRef: MatDialogRef<RegisterComponent>,private authService:AuthService, private alertify: AlertifyService,private router: Router,private fb:FormBuilder) { }

  ngOnInit() {
  
    (this.bsconfig = {
      containerClass: "theme-red",
      dateInputFormat: "YYYY-MM-DD",
      // minDate: new Date(2019, 1, 1),
      // maxDate: new Date(2019, 11, 2)
    }),
    this.createForm();
    
  }
  createForm(){
    this.registerForm=this.fb.group(
      {
        userName:['',[Validators.required,Validators.minLength(4),Validators.maxLength(20)]],
        firstName:['',[Validators.required,Validators.minLength(4),Validators.maxLength(20)]],
        lastName:['',[Validators.required,Validators.minLength(4),Validators.maxLength(20)]],
        email:['',[Validators.required,Validators.minLength(4),Validators.maxLength(100)]],
        aboutMe:['',[Validators.required,Validators.minLength(4),Validators.maxLength(100)]],
        status:['',[Validators.required,Validators.minLength(4),Validators.maxLength(20)]],
        gender:['male'],
        dateOfBirth:[null,[Validators.required]],
        password: [
          "",
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(8)
          ]
        ],
        confirmpassword:['',[Validators.required,Validators.minLength(4),Validators.maxLength(20)]]
      },
      { validator: this.passwordMatchValidator}
      );
      
   }
   passwordMatchValidator(g: FormGroup) {
    return g.get("password").value === g.get("confirmpassword").value
      ? null
      : { mismatch: true };
  }
  

   register(){
    if(this.registerForm.valid){
      this.user=Object.assign({},this.registerForm.value)
      this.authService.register(this.user).subscribe(data=>{
        this.alertify.success('register succes');
        this.dialogRef.close();
      }),error=>{
        this.alertify.error(error);
      }
      }
    }
   
  

}
