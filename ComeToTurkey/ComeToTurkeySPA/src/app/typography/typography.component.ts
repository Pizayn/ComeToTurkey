import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminDashboard } from 'app/_models/admin/admindashboard';
import { Blog } from 'app/_models/blog';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { AddBlogComponent } from 'app/blog/add-blog/add-blog.component';
import { UserService } from 'app/_services/user.service';
import { Destination } from 'app/_models/destination';

@Component({
  selector: 'app-typography',
  templateUrl: './typography.component.html',
  styleUrls: ['./typography.component.css']
})
export class TypographyComponent implements OnInit {

  destinations:Destination[];
  blog:Blog;
  dashboard:AdminDashboard;
  displayedColumns: string[] = ['destinationId', 'regionName', 'cityName','mainPhotoUrl','actions'];
  dataSource = new MatTableDataSource<Destination>(this.destinations);

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  constructor(private route:ActivatedRoute,private userService:UserService,public dialog: MatDialog) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.route.data.subscribe(data=>{
      this.dashboard=data['dashboard']
    })
    this.destinations=this.dashboard.destinations;
    this.dataSource.paginator = this.paginator;
    this.dataSource.data=this.destinations
  }
}
