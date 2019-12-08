import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminDashboard } from 'app/_models/admin/admindashboard';
import { Blog } from 'app/_models/blog';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { AddBlogComponent } from 'app/blog/add-blog/add-blog.component';
import { UserService } from 'app/_services/user.service';

import { AddNewsComponent } from './add-news/add-news.component';
import { News } from 'app/_models/news';
import { AdminService } from 'app/_services/admin.service';

@Component({
  selector: 'app-icons',
  templateUrl: './icons.component.html',
  styleUrls: ['./icons.component.css']
})
export class IconsComponent implements OnInit {

  news:News[];
  news2:News;
  blog:Blog;
  dashboard:AdminDashboard;
  displayedColumns: string[] = ['newId', 'title','mainPhotoUrl','actions'];
  dataSource = new MatTableDataSource<News>(this.news);

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(private route:ActivatedRoute,private userService:UserService,public dialog: MatDialog,private adminService:AdminService) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.route.data.subscribe(data=>{
      this.dashboard=data['dashboard']
    })
    this.news=this.dashboard.news;
    this.dataSource.paginator = this.paginator;
    this.dataSource.data=this.news
  }
  openAddNewsDiaolog(): void {
    const dialogRef = this.dialog.open(AddNewsComponent, {
      height:'642px',
      position: {
        top: '50px',
       
      }
      
     
     
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openUpdateNewsDiaolog(id:number) {
    this.adminService.getNews(id).subscribe(data=>{
      this.news2=data;
    })
    this.dialog.open(AddNewsComponent, {
      data:this.news2,
    });
  }

}
