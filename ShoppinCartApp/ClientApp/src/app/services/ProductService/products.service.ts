import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { CartItem } from '../../models/CartItem';
import { Category, SubCategory } from '../../models/category';
import { products } from '../../models/Products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl: string = "";
  constructor(private http: HttpClient) {
    this.baseUrl = environment.apiUrl;
  }

  getAllProducts(): Observable<products[]> {
    debugger;
    return this.http.get<products[]>(this.baseUrl + "/api/Products/getallproducts", { responseType: "json" });
  }

  getProductById(id: any): Observable<products> {
    debugger;
    return this.http.get<products>(this.baseUrl + "/api/Products/getproductbyid/"+id, { responseType: "json" });
  }

  getAllCategory(): Observable<Category[]> {
    debugger;
    return this.http.get<Category[]>(this.baseUrl + "/api/Category/getallcategories", { responseType: "json" });
  }

  getAllSubCategory(): Observable<SubCategory[]> {
    debugger;
    return this.http.get<SubCategory[]>(this.baseUrl + "/api/SubCategory/getallsubcategories", { responseType: "json" });
  }

  getAllSubCategoryById(id: string): Observable<SubCategory[]> {
    debugger;
    return this.http.get<SubCategory[]>(this.baseUrl + "/api/SubCategory/getallsubcategoriesbyid/" + id, { responseType: "json" });
  }

  getCartProductsCount(): any {
    return this.http.get<number>(this.baseUrl + "/api/CartItems/getcartcount", { responseType: "json" });
  }

  getCartItems(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(this.baseUrl + "/api/CartItems/getallcartitems", { responseType: "json" });
  }

  AddProducttoCart(cartItem: any): Observable<any> {
    debugger;
    return this.http.post<CartItem>(this.baseUrl + "/api/CartItems/additemstocart", JSON.stringify(cartItem), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      })
    });
  }

  UploadImage(formData: FormData,id:any) {
    let apiUrl = "/api/Products/UploadProductImage/";
    return this.http.post(this.baseUrl + apiUrl+id, formData);
  };

  AddProduct(product: any): Observable<any> {
    debugger;
    return this.http.post<products>(this.baseUrl + "/api/Products/addproducts", JSON.stringify(product), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      })
    });
  }
}
