import { Component, OnInit } from '@angular/core';
import { CartItem } from '../../models/CartItem';
import { ProductsService } from '../../services/ProductService/products.service';

@Component({
  selector: 'app-cartitems',
  templateUrl: './cartitems.component.html',
  styleUrls: ['./cartitems.component.css']
})
export class CartitemsComponent implements OnInit {
  products: CartItem[] = [];

  constructor(private prodService: ProductsService) { }

  ngOnInit() {
    this.getAllCartItems();
  }
  getAllCartItems() {
    debugger;
    this.prodService.getCartItems().subscribe(res => {
      this.products = res;
    });
  }
}
