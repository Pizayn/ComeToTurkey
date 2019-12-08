import { Component, OnInit } from '@angular/core';
import { AddBlogComponent } from '../add-blog/add-blog.component';
import { MatDialog } from '@angular/material';
import { UserService } from 'app/_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'app/_services/auth.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { Blog } from 'app/_models/blog';
import { Pagination, PaginationResult } from 'app/_models/pagination';
import { BlogCategory } from 'app/_models/blogcategory';

@Component({
  selector: 'app-user-blog',
  templateUrl: './user-blog.component.html',
  styleUrls: ['./user-blog.component.scss']
})
export class UserBlogComponent implements OnInit {
  blogs:Blog[];
  blogCategories:BlogCategory[];
  pagination:Pagination;
  blogCategory:number;
  blogParams:any={};
  constructor(public dialog:MatDialog,private userService: UserService, private authService: AuthService,
    private route: ActivatedRoute, private alertify: AlertifyService,) { }

  ngOnInit() {
    this.route.data.subscribe( data => {
      // tslint:disable-next-line:no-string-literal
      this.blogs = data['blogs'].result;
      // tslint:disable-next-line:no-string-literal
      this.pagination = data['blogs'].pagination;
    
     
    });
   this.userService.getBlogCategories().subscribe(data=>{
     this.blogCategories=data;
   })
   this.route.queryParams.subscribe(params=>{
     this.blogCategory=params['blogCategoryId']

   })
  }
  openAddBlogDiaolog(): void {
    const dialogRef = this.dialog.open(AddBlogComponent, {
      height:'642px',
      position: {
        top: '50px',
       
      }
      
     
     
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  loadBlogs(categoryId?:any) {
  
    this.blogParams.blogCategoryId=categoryId;
    this.userService.getBlogs(this.authService.decodedToken.nameid, this.pagination.currentPage,
          this.pagination.itemsPerPage,this.blogParams)
          .subscribe( (res: PaginationResult<Blog[]>) => {
            
              this.blogs = res.result;
              this.pagination = res.pagination;
             

          }, error => {
            this.alertify.error(error);
          });
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadBlogs();
  }
  

}
