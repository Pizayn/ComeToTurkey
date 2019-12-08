import { Component, OnInit, Inject } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FileUploader } from 'ng2-file-upload';
import { Photo } from 'app/_models/photo';
import { UserService } from 'app/_services/user.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { environment } from 'environments/environment';
import { AuthService } from 'app/_services/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Blog } from 'app/_models/blog';
import { error } from '@angular/compiler/src/util';
import { RegisterComponent } from 'app/account/register/register.component';
import { BlogCategory } from 'app/_models/blogcategory';
import { City } from 'app/_models/city';
import { News } from 'app/_models/news';
import { AdminService } from 'app/_services/admin.service';
import { MatDialogRef, MAT_DIALOG_DATA,MatDialog } from '@angular/material';

@Component({
  selector: 'app-add-news',
  templateUrl: './add-news.component.html',
  styleUrls: ['./add-news.component.scss']
})
export class AddNewsComponent implements OnInit {
  uploader:FileUploader;
  public hasBaseDropZoneOver = false;
  public hasAnotherDropZoneOver = false;
  baseUrl=environment.apiUrl;
  response:string;
  news:News;
  model2:any;
 public blogForm:FormGroup
 cities:City[];
 blogCategories:BlogCategory[];
  public Editor = ClassicEditor;
  public model = {
    editorData: '<p>Hello, fuckin world!</p>'
};

  constructor(public dialogRef: MatDialogRef<AddNewsComponent> , private authService:AuthService,private adminService:AdminService,private alertify:AlertifyService,private fb:FormBuilder,@Inject(MAT_DIALOG_DATA) public data: News) { }

  ngOnInit() {
    this.initializeUploader();
    this.createForm();
    this.model2=this.data.mainPhotoUrl
   

  }
  public fileOverBase(e:any):void {
    this.hasBaseDropZoneOver = e;
  }
  createForm()
  {
    this.blogForm=this.fb.group(
      {
        text:['',[Validators.required]],
        title:['',[Validators.required,]],
        mainPhotoUrl:['',[Validators.required]],
       
      }
    )
  }
  createNews(){
    if(this.blogForm.valid)
    {
      this.news=Object.assign({},this.blogForm.value);
      this.adminService.createNews(this.news).subscribe(data=>{
       this.alertify.success("Blog successfully created");
       this.dialogRef.close();
      },error=>{
        this.alertify.error("Blog not created");
      })

    }
  }

  
  initializeUploader(){
    this.uploader=new FileUploader({
      url: this.baseUrl + 'users/' + this.authService.decodedToken.nameid + '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      maxFileSize: 10 * 1024 * 1024,
      autoUpload: false
    });
    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };
    this.uploader.onSuccessItem = (item, response , status , headers) => {
      if(response){
        const res:Photo=JSON.parse(response)
        this.model2=res.url

         

        };
       
      }
    }
    

}
