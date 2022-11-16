import { Component, OnInit, ViewChild } from '@angular/core';
import { UserModel } from '../../models/UserModel';
declare var paypal;
import { isNullOrUndefined } from 'util';
import { LoginService } from '../../services/login.service';
import { PaymentDetails, products } from '../../models/Products';
import { ProductsService } from '../../services/ProductService/products.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-orderpayment',
  templateUrl: './orderpayment.component.html',
  styleUrls: ['./orderpayment.component.css']
})
export class OrderpaymentComponent implements OnInit {

  user: UserModel;
  totalamount: number;
  isDisabled: boolean;
  product: products = new products()

  isAuthenticated = false;
  userName = "";
  emailId = "";
  role = "";
  currentUserId: string="";
  id: string="";
  amount: number;

  paymentHandler: any = null;

  @ViewChild('paypal', { static: true }) paypalElement: any;

  constructor(private loginService: LoginService, private productservice: ProductsService, private route: ActivatedRoute) { }

  ngOnInit() {
   this.route.params.subscribe(params => {
     this.id = params['id'];
    this.getProductById(this.id);
   });
    this.getLoginDetails();
    paypal.Buttons().render(this.paypalElement.nativeElement);
    //paypal
    //  .Buttons({
    //    createOrder: (data, actions) => {
    //      if (isNullOrUndefined(this.currentUserId)) {
    //        return;
    //      }
    //      else {
    //        return actions.order.create({
    //          purchase_units: [
    //            {
    //              description: 'Purchasing Items',
    //              amount: {
    //                currency_code: 'USD',
    //                value: this.product.price,
    //              }
    //            }
    //          ]
    //        });
    //      }
    //    },
    //    onApprove: () => {
    //      window.alert("Success!");
    //      this.loadWallet();
    //    },
    //    style: {
    //      layout: 'horizontal',
    //      shape: 'pill',
    //      tagline: false,
    //      height: 35
    //    },
    //    onError: err => {
    //      window.alert("Payment Failed!!");
    //    }
    //  })
    //  .render(this.paypalElement.nativeElement);

    this.invokeStripe();
  }

  getProductById(id: any) {
    this.productservice.getProductById(id).subscribe(x => {
      this.product = x;
    });
  }

  getLoginDetails() {
    this.loginService.getLoginStatus().subscribe(x => {
      this.isAuthenticated = x;
    })
    this.userName = this.loginService.getUserName();
    this.currentUserId = this.loginService.getCurrentUserId();
    this.emailId = this.loginService.getEmail();
    this.role = this.loginService.getRole();
  }

  invokeStripe() {
    if (!window.document.getElementById('stripe-script')) {
      const script = window.document.createElement("script");
      script.id = "stripe-script";
      script.type = "text/javascript";
      script.src = "https://checkout.stripe.com/checkout.js";
      script.onload = () => {
        this.paymentHandler = (<any>window).StripeCheckout.configure({
          key: 'pk_test_51K2a0pSFu3x1gLyFCzCeX5eF3Ux5NmzbmihhuQsJ0bqOoXg7jkoDm3g3puQOSWjhYrQ4rJ59jRiE1YmjTEpnqeRf00g08Hzf0b',
          locale: 'auto',
          token: function (stripeToken: any) {
            debugger;
            console.log(stripeToken)
            alert('Payment has been successfull!');
          }
        });
      }
      window.document.body.appendChild(script);
    }
  }

   initializePayment(amount: number) {
    const paymentHandler = (<any>window).StripeCheckout.configure({
      key: 'pk_test_51K2a0pSFu3x1gLyFCzCeX5eF3Ux5NmzbmihhuQsJ0bqOoXg7jkoDm3g3puQOSWjhYrQ4rJ59jRiE1YmjTEpnqeRf00g08Hzf0b',
      locale: 'auto',
      token: function (stripeToken: any) {
        console.log({ stripeToken })
        alert('Stripe token generated!');
      }
    });


    paymentHandler.open({
      name: 'FreakyJolly',
      description: 'Buying a Hot Coffee',
      amount: amount * 100
    });
   }

  loadWallet() {
    debugger;
    let userdetails = new PaymentDetails();
    userdetails.UserId = this.currentUserId;
    userdetails.Amount = +this.product.price;

    this.loginService.loadWallet(userdetails).subscribe((res) => {
      let paymentConfirmationText: string = res;
      if (paymentConfirmationText == 'Added') {
        window.alert(paymentConfirmationText);
        window.location.reload();
      }
      else {
        window.alert(paymentConfirmationText);
      }

    });

  }

}
