import {Component, OnInit, Input} from '@angular/core';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { User } from 'app/_models/user';
import { UserService } from 'app/_services/user.service';
@Component({
  selector: 'app-user-search',
  templateUrl: './user-search.component.html',
  styleUrls: ['./user-search.component.scss']
})
export class UserSearchComponent implements OnInit {

  myControl = new FormControl();
  @Input() options: User[];
   
  
  filteredOptions: Observable<User[]>;
  constructor(private userService:UserService){}
  ngOnInit() {
  
    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => typeof value === 'string' ? value : value.firstName),
        map(firstName => firstName ? this._filter(firstName) : this.options)
      );
  }

  displayFn(user?: User): string | undefined {
    return user ? user.firstName : undefined;
  }

  private _filter(firstName: string): User[] {
    const filterValue = firstName.toLowerCase();

    return this.options.filter(option => option.firstName.toLowerCase().indexOf(filterValue ) > -1 || 
    option.lastName.toLowerCase().indexOf(filterValue ) > -1);
  }

}
