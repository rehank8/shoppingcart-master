import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { UserModel } from '../../models/UserModel';
import { LoginService } from '../../services/login.service';
import { RegisterUserDTO, services } from '../../services/services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLogin: boolean = true;

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }

  OnLoginPopUp(value: any) {
    this.isLogin = value === 'login' ? true : false;

  }

  login(form: NgForm) {
    debugger;
    var reg = new UserModel();
    reg.username = form.value.username;
    reg.password = form.value.password;
    this.loginService.login(reg).subscribe(res => {
      debugger;
      let token = (<any>res).token;
      let decodedToken = jwt_decode(token);
      this.loginService.setToken(token);
      if (decodedToken.role == "User")
        this.router.navigate(["/"]);
      else {
        this.router.navigate(["/users"]);

      }
    });
  }

}

