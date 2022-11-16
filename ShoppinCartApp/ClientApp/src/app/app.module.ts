import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UsersComponent } from './Users/users/users.component';
import { LoginComponent } from './Login/login/login.component';
import { services } from './services/services';
import { HomeComponent } from './home/home/home.component';
import { ProductsService } from './services/ProductService/products.service';
import { CartitemsComponent } from './home/cartitems/cartitems.component';
import { RegisterusersComponent } from './home/registerusers/registerusers.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PaymentComponent } from './payment/payment/payment.component';
import { ManageproductsComponent } from './Admin/manageproducts/manageproducts.component';
import { OrderpaymentComponent } from './payment/orderpayment/orderpayment.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UsersComponent,
    LoginComponent,
    CartitemsComponent,
    RegisterusersComponent,
    PaymentComponent,
    ManageproductsComponent,
    OrderpaymentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, NgMultiSelectDropDownModule, NgbModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent, pathMatch: 'full'  },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'cart', component: CartitemsComponent },
      { path: 'users', component: RegisterusersComponent },
      { path: 'orderdetails/:id', component: OrderpaymentComponent },
      { path: 'manageproducts', component: ManageproductsComponent },
      { path: 'payment', component: PaymentComponent },
    ]),
  ],
  providers: [services, ProductsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
