import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'app/_services/auth.service';
import { environment } from 'environments/environment';
import { FileUploader } from 'ng2-file-upload';
import { Photo } from 'app/_models/photo';
import { UserService } from 'app/_services/user.service';
import { AlertifyService } from 'app/_services/alertify.service';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.scss']
})
export class PhotoEditorComponent implements OnInit {
  uploader:FileUploader;
  public hasBaseDropZoneOver = false;
  public hasAnotherDropZoneOver = false;
  baseUrl=environment.apiUrl;
  response:string;
 @Input() photos:Photo[];
 @Output() changeEditPhoto = new EventEmitter<string>();
 currentMainPhoto: Photo;


  constructor(private authService:AuthService,private userService:UserService,private alertify:AlertifyService) { }

  ngOnInit() {
    this.initializeUploader();
  }
  public fileOverBase(e:any):void {
    this.hasBaseDropZoneOver = e;
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
        const photo={
         id:res.id,
         url:res.url,
         isMain:res.isMain,
         dateAdded:res.dateAdded

         

        };
        if (photo.isMain) {
          this.authService.changeMemberPhoto(photo.url);
          this.authService.user.photoUrl = photo.url;
          localStorage.setItem('user', JSON.stringify(this.authService.user));
        }
        this.photos.push(photo);
      }
    }


  }
  SetMain(photo: Photo) {
    this.userService.setMainPhoto(this.authService.decodedToken.nameid, photo.id).subscribe((res) => {
      this.currentMainPhoto = this.photos.filter(i => i.isMain === true)[0];
      this.currentMainPhoto.isMain = false;
      photo.isMain = true;
      this.authService.changeMemberPhoto(photo.url);
      this.authService.user.photoUrl = photo.url;
      localStorage.setItem('user', JSON.stringify(this.authService.user));
      this.alertify.success('You set succesfully your main photo');
    }, (error) => {
      this.alertify.error('It could not set as main photo');
    });
  }
  DeletePhoto(photoId) {
    this.alertify.confirm('Are you sure to delete this photo?', () => {
      this.userService.DeletePhoto(this.authService.decodedToken.nameid, photoId).subscribe(() => {
        this.photos.splice(this.photos.findIndex(p => p.id === photoId), 1);
        this.alertify.success('You have deleted your photo');
      }, error => {
        this.alertify.error('Failed to delete the photo');
      });
    });
  }

}
