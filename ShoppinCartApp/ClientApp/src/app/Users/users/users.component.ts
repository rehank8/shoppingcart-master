import { Component, OnInit } from '@angular/core';
import { RegisterUserDTO } from '../../services/services';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  user: RegisterUserDTO = new RegisterUserDTO();
  users: RegisterUserDTO[] =[];
  constructor() { }

  ngOnInit() {
  }

}
