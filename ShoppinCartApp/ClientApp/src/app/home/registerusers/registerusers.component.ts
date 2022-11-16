import { Component, OnInit, ViewChild } from '@angular/core';
import { UserDTOPaginationEntityDto } from '../../models/UserDTOPaginationEntityDto';
import { UserModel } from '../../models/UserModel';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-registerusers',
  templateUrl: './registerusers.component.html',
  styleUrls: ['./registerusers.component.css']
})
export class RegisterusersComponent implements OnInit {
  @ViewChild('AddEditForm', { static: false }) AddEditForm: any;
  page: number;
  pageSize: number;
  collectionSize: number;
  users: UserModel[] = [];
  user: UserDTOPaginationEntityDto = new UserDTOPaginationEntityDto();
  isShowAddPopup: boolean;
  isChecked: boolean;


  constructor(private loginService: LoginService) { }

  ngOnInit() {
    window.scrollTo(0, 0);
    this.page = 1;
    this.pageSize = 5;
    this.getUsers();
  }



  showBackButton: boolean;

  getUsers() {
    debugger;
    this.loginService.getAllUsers(this.page, this.pageSize).subscribe(res => {
      this.users = res.entities;
      this.user.count = res.count;
      this.collectionSize = this.user.count;
    }, error => {
      // this.alertService.error(error);
    })
  }

  refreshUsers() {
    this.getUsers();
  }

  pageChange(pagenumber) {
    this.page = pagenumber;
    this.getUsers();
  }

  OnClosePopup() {
    this.isShowAddPopup = false;
  }

  OnAddModalPopup() {
    this.isShowAddPopup = true;
  }

  addUser() {
    debugger;
    var users = new UserModel();
    users.username = this.AddEditForm.value.username;
    users.password = this.AddEditForm.value.password;
    users.emailId = this.AddEditForm.value.email;
    users.phoneNo = this.AddEditForm.value.phone;
    users.isActive = this.isChecked;
    if (this.AddEditForm.value.username == "admin")
      users.fkRoleId = 1;
    else
      users.fkRoleId = 3;
    users.address = this.AddEditForm.value.address;
    this.loginService.addUsers(users).subscribe(res => {
      this.getUsers();
      this.isShowAddPopup = false;
    });
  }
}
