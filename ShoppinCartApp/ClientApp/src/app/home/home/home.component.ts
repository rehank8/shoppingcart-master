import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SharableService } from '../../Common/sharable.service';
import { CartItem } from '../../models/CartItem';
import { products } from '../../models/Products';
import { ProductsService } from '../../services/ProductService/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  products: products[] = [];

  constructor(private prodService: ProductsService, private router: Router, private shareDate: SharableService) {
    this.invokeStripe();
  }

  ngOnInit() {
    this.getAllProducts();
  }


  getAllProducts() {
    debugger;
    this.prodService.getAllProducts().subscribe(res => {
      this.products = res;
    
    });
  }

  AddToCart(product: any) {
    debugger;
    var cart = new CartItem();
    cart.Category = product.Category;
    cart.fKProductId = product.id;
    cart.image = product.image;
    cart.price = product.price;
    this.prodService.AddProducttoCart(cart).subscribe(res => {
      this.router.navigate([this.router.url])
      this.shareDate.sendData(true);
    });
  }

  paymentHandler: any = null;

  invokeStripe() {
    debugger;
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

  filter(form: NgForm) {
    debugger;
    var min = form.value.minRange;
    this.prodService.getAllProducts().subscribe(res => {
      this.products = res;
      var r = this.products.filter(x => x.price > form.value.minRange && x.price < form.value.maxRange);
      this.products = r;

    });
  }
  

  //initializePayment(amount: number) {
  //  const paymentHandler = (<any>window).StripeCheckout.configure({
  //    key: 'pk_test_51K2a0pSFu3x1gLyFCzCeX5eF3Ux5NmzbmihhuQsJ0bqOoXg7jkoDm3g3puQOSWjhYrQ4rJ59jRiE1YmjTEpnqeRf00g08Hzf0b',
  //    locale: 'auto',
  //    token: function (stripeToken: any) {
  //      console.log({ stripeToken })
  //      alert('Stripe token generated!');
  //    }
  //  });


  //  paymentHandler.open({
  //    name: 'FreakyJolly',
  //    description: 'Buying a Hot Coffee',
  //    amount: amount * 100
  //  });
  //}

  goToDetails(product: any) {
    debugger;
    this.router.navigate(["/orderdetails/" + product.id]);
      }
}
