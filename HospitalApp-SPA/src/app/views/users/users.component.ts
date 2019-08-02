import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../Services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../../Model/User';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor(private usersService: UserService, private route: ActivatedRoute) { }
  users: User[];
  ngOnInit() {

    this.route.data.subscribe(data => {   // the value has been passed to the resolver and we subscribe to it
     console.log(data.user.result);
      this.users = data.user.result;

    });

}
}
