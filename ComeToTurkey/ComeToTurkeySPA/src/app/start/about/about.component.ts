import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/_services/user.service';
import { About } from 'app/_models/about';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
about:About
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getAboutPage().subscribe(data=>{
      this.about=data;
    })
  }

}
