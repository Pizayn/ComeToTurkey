import { Component, OnInit } from '@angular/core';
import { Pagination, PaginationResult } from 'app/_models/pagination';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { ActivatedRoute} from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Follow } from 'app/_models/follow';
import { Comment } from 'app/_models/comment';
import { Blog } from 'app/_models/blog';
import { BlogCategory } from 'app/_models/blogcategory';
import { BlogLike } from 'app/_models/bloglike';
import { City } from 'app/_models/city';


@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
  styleUrls: ['./blog-detail.component.scss']
})
export class BlogDetailComponent implements OnInit {
comments: Comment[];
likes:BlogLike[];
pagination: Pagination;
newMessage:any={};
public commentForm:FormGroup;
currentBlogId:number;
blog:Blog;
sayi:number=0;
blogCategory:BlogCategory;
blogCategoryId:number;
city:City;
public blogCommentCount:number;
constructor(private userService: UserService, private authService: AuthService,
  private route: ActivatedRoute, private alertify: AlertifyService,private fb:FormBuilder) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      // tslint:disable-next-line:no-string-literal
      this.comments = data['comments'].result;
      // tslint:disable-next-line:no-string-literal
      this.pagination = data['comments'].pagination;
      this.blog = data['blog'];
     
      
     
    });
    this.route.params.subscribe(params=> {
      this.currentBlogId=params['id']
    })
    this.blogCommentCount=this.blog.commentsReceivedCount;
    this.blogCategory=this.blog.blogCategory;
    this.city=this.blog.city;
    this.likes=this.blog.blogLikes
    this.blogCategoryId=this.blog.blogCategory.blogCategoryId;

  }


  sendLike(){
    this.userService.sendLike(this.authService.decodedToken.nameid,this.currentBlogId).subscribe(data=>{
      this.alertify.success("you liked" + this.blog.userFirstName + "post");
      const like=new BlogLike();
      like.likerId=this.authService.decodedToken.nameid
    
     this.likes.push(like);
     this.blog.blogLikesCount=this.blog.blogLikesCount+1;

   
     
    })
    
  
  }
  sendUnLikes(){
    this.userService.sendUnLike(this.authService.decodedToken.nameid,this.currentBlogId).subscribe(data=>{
      this.alertify.success("you  UnLiked" + this.blog.userFirstName + "post");
      this.likes.splice(this.likes.findIndex(p => p.likerId ===  this.authService.decodedToken.nameid), 1);
      this.blog.blogLikesCount=this.blog.blogLikesCount-1;
    })
    
  
  }
  isLikeExist()
  {
    if(this.likes.find(p => p.likerId ==  this.authService.decodedToken.nameid) ){
      return true;
    }
    if(this.likes.find(p => p.likerId !=  this.authService.decodedToken.nameid) ){
      return false;
    }
   
   
   
   
   
  
     
  
    
  
  }



}
