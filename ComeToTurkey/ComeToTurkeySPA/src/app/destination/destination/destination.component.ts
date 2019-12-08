import { Component, OnInit } from '@angular/core';
import { Destination } from 'app/_models/destination';
import { UserService } from 'app/_services/user.service';

@Component({
  selector: 'app-destination',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.scss']
})
export class DestinationComponent implements OnInit {
destinations:Destination[];
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getDestinations().subscribe(data=>{
      this.destinations=data;
    })
  }

}
