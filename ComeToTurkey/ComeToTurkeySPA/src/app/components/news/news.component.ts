import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/_services/user.service';
import { News } from 'app/_models/news';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
news:News[]
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getNews().subscribe(data=>{
      this.news=data;
    })
  }

}
