import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/_services/user.service';
import { Blog } from 'app/_models/blog';

@Component({
  selector: 'app-popular-user-blogs',
  templateUrl: './popular-user-blogs.component.html',
  styleUrls: ['./popular-user-blogs.component.scss']
})
export class PopularUserBlogsComponent implements OnInit {
blogs:Blog[];
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getPopularBlogs().subscribe(data=>{
      this.blogs=data;
    })
  }

}
