import { Component, OnInit } from '@angular/core';
import { News } from 'app/_models/news';
import { UserService } from 'app/_services/user.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {
news:News[]
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getNews().subscribe(data=>{
      this.news=data;
    })

  }

}
