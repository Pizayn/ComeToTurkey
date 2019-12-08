import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { RegisterComponent } from 'app/account/register/register.component';
import { UserService } from 'app/_services/user.service';
import { Destination } from 'app/_models/destination';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public dialog:MatDialog,private userService:UserService) { }

  ngOnInit() {
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(RegisterComponent, {
    
     
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}
