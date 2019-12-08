import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/_services/user.service';
import { Destination } from 'app/_models/destination';

@Component({
  selector: 'app-destinationview',
  templateUrl: './destination.component.html',
  styleUrls: ['./destination.component.scss']
})
export class DestinationViewComponent implements OnInit {
destinations:Destination[];
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.userService.getDestinations().subscribe(data=>{
      this.destinations=data;
    })
  }

}
