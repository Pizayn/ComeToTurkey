import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminDashboard } from 'app/_models/admin/admindashboard';
import { Blog } from 'app/_models/blog';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { AddBlogComponent } from 'app/blog/add-blog/add-blog.component';
import { UserService } from 'app/_services/user.service';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {
  blogs:Blog[];
  blog:Blog;
  dashboard:AdminDashboard;
  displayedColumns: string[] = ['blogId', 'title', 'cityName', 'blogCategoryName','mainPhotoUrl','actions'];
  dataSource = new MatTableDataSource<Blog>(this.blogs);

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(private route:ActivatedRoute,private userService:UserService,public dialog: MatDialog) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.route.data.subscribe(data=>{
      this.dashboard=data['dashboard']
    })
    this.blogs=this.dashboard.blogs;
    this.dataSource.paginator = this.paginator;
    this.dataSource.data=this.blogs
  }
  openDialog(id:number) {
    this.userService.getBlog(1,1010).subscribe(data=>{
      this.blog=data;
    })
    this.dialog.open(AddBlogComponent, {
      data:this.blog,
    });
  }
}


