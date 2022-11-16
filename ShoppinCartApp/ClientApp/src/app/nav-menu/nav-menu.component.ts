import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharableService } from '../Common/sharable.service';
import { CartItem } from '../models/CartItem';
import { Category, SubCategory } from '../models/category';
import { LoginService } from '../services/login.service';
import { ProductsService } from '../services/ProductService/products.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  products: number;
  totalprice: number=0;
  isLogin: boolean;
  isUser: boolean = true;
  isshowusers: boolean;
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  isAdmin: boolean;
  cartitems: CartItem[] = [];

  constructor(private prodService: ProductsService, private loginService: LoginService, private route: Router, private shareData: SharableService) {
    var href = window.location.href;
    if (href == "https://localhost:4200/users" || href == "https://localhost:4200/login")
      this.isUser = false;
    this.loginService.getLoginStatus().subscribe((res: boolean) => {
      this.isLogin = res;
    });
  }
  ngOnInit(): void {
    //this.loginService.getLoginStatus().subscribe((res: boolean) => {
    //  this.isLogin = res;
    //  if (this.isLogin) {
    //    if (localStorage.getItem("role") == "Admin")
    //      this.isUser = true;
    //  }
    //});
    this.getAllCartItems();
    debugger;
    if (localStorage.getItem("role") == "Admin")
      this.isAdmin = true;
    this.getAllProducts();
    this.getAllCategories();
  }

  getAllProducts() {
    debugger;
    if (this.isLogin) {
      this.prodService.getCartProductsCount().subscribe(res => {
        this.products = <number>res;
      });
    }
    else {
      this.products = 0;
    }
  }

  getAllCartItems() {
    debugger;
    this.prodService.getCartItems().subscribe(res => {
      this.cartitems = res;
      this.totalprice = 0;
      this.cartitems.forEach(r => {
        debugger;
        this.totalprice = this.totalprice + r.price;
      });
    });
  }

  getAllCategories() {
    debugger;
    this.prodService.getAllCategory().subscribe(res => {
      this.categories = res;
      //this.categories.forEach(x => {
      //  this.prodService.getAllSubCategory().subscribe(res1 => {
      //    this.subcategories = res1;
      //    x.subCategories = this.subcategories.filter(y => y.fKCategoryId == x.Id);
      //  });
      //});
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  OnCart() {
    if (this.isLogin === true) {
      this.route.navigate(["/cart"])
    }
    else {
      this.route.navigate(["/login"])
    }
  }

  logout() {
    this.loginService.logout();
    this.route.navigate(["/login"]);
  }
}
