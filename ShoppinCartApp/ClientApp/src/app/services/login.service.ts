import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserModel } from '../models/UserModel';
import { RegisterUserDTO } from './services';
import * as jwt_decode from 'jwt-decode';
import { Local } from 'protractor/built/driverProviders';
import { UserDTOPaginationEntityDto } from '../models/UserDTOPaginationEntityDto';
import { PaymentDetails } from '../models/Products';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl: string = "https://localhost:44373";
  private loginStatus: BehaviorSubject<boolean>;
  constructor(private http: HttpClient) {
    this.loginStatus = new BehaviorSubject(this.isAuthenticated());
  }

  login(body: UserModel | undefined): Observable<any> {
    return this.http.post<any>(this.baseUrl + "/api/AuthenticationAPI/Login", JSON.stringify(body), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      })
    });
  }

  addUsers(users:any) {
    return this.http.post<any>(this.baseUrl + "/api/UsersAPI/addusers", JSON.stringify(users), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      })
    });
  }
    
  getAllUsers(pagenumber: number, pagesize: number): Observable<UserDTOPaginationEntityDto> {
    debugger;
    return this.http.post<UserDTOPaginationEntityDto>(this.baseUrl + "/api/UsersAPI/getallusers/"+ pagenumber + "/" + pagesize, { responseType: "json" });
    //return this.http.get<UserModel[]>(this.baseUrl + "/api/UsersAPI/getactiveusers", { responseType: "json" });
  }


  setToken(token: any) {
    let decodedToken = jwt_decode(token);
    localStorage.setItem("name", decodedToken.name);
    localStorage.setItem("email", decodedToken.email);
    localStorage.setItem("role", decodedToken.role);
    localStorage.setItem("id", decodedToken.id);
    localStorage.setItem("jwt", token);
    this.loginStatus.next(true);
  }

  getUserName(): string {
    return localStorage.getItem("name");
  }
  getCurrentUserId(): string {
    return localStorage.getItem("id");
  }

  getEmail(): string {
    return localStorage.getItem("email");
  }

  getRole(): string {
    return localStorage.getItem("role");
  }

  isAuthenticated(): boolean {
    if (localStorage["jwt"]) {
      return true;
    }
    return false;
  }

  logout() {
    debugger;
    localStorage.removeItem("jwt");
    localStorage.removeItem("name");
    localStorage.removeItem("email");
    localStorage.removeItem("role");
    this.loginStatus.next(false);
  }

  getLoginStatus(): Observable<boolean> {
    debugger;
    return this.loginStatus.asObservable();
  }

  loadWallet(userdetails: PaymentDetails): Observable<any> {
    debugger;
    let apiUrl = this.baseUrl + "Payment/LoadWallet/";
    return this.http.post<any>(apiUrl, userdetails);
  }

}

function _observableMergeMap(arg0: (response_: any) => any): import("rxjs").OperatorFunction<ArrayBuffer, unknown> {
  throw new Error('Function not implemented.');
}
