import { Component, OnInit, ViewChild } from '@angular/core';
import { Category, SubCategory } from '../../models/category';
import { products } from '../../models/Products';
import { ProductsService } from '../../services/ProductService/products.service';

@Component({
  selector: 'app-manageproducts',
  templateUrl: './manageproducts.component.html',
  styleUrls: ['./manageproducts.component.css']
})
export class ManageproductsComponent implements OnInit {

  product: products = new products();
  products: products[] = [];
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  image: string;
  @ViewChild('AddEditForm', { static: false }) AddEditForm: any;
  page: number;
  PKCategoryId: string;
  pageSize: number;
  collectionSize: number;
  isShowAddPopup: boolean = false;
  isChecked: boolean;

  constructor(private productService: ProductsService) { }

  ngOnInit() {
    this.getallproducts();
    this.getallcategories();
  }

  getallproducts() {
    this.productService.getAllProducts().subscribe(res => {
      this.products = res;
    });
  }

  OnClosePopup() {
    this.AddEditForm.reset();
    this.isShowAddPopup = false;
  }

  OnAddModalPopup() {
    this.isShowAddPopup = true;
  }

  getallcategories() {
    debugger;
    this.productService.getAllCategory().subscribe(res => {
      this.categories = res;
    });
  }

  getallsubcategories() {
    this.productService.getAllSubCategory().subscribe(res => {
      this.subcategories = res;
    });
  }

  getallsubcategoriesbyId(id: string) {
    this.productService.getAllSubCategoryById(id).subscribe(res => {
      this.subcategories = res;
    });
  }

  OnChangeCategories() {
    debugger;
    this.PKCategoryId = this.product.fKCategoryId;
    this.getallsubcategoriesbyId(this.PKCategoryId);
    //this.SubCategoriesBycategories = this.subcategories.filter(s => s.FkcategoryId = this.PKCategoryId);

  };
  addProduct() {
    debugger;
    var prod = new products();
    prod.productName = this.AddEditForm.value.name;
    prod.price = this.AddEditForm.value.price;
    prod.description = this.AddEditForm.value.description;
    prod.color = this.AddEditForm.value.color;
    prod.fKBrandId = this.AddEditForm.value.brand;
    prod.isActive = this.isChecked;
    this.productService.AddProduct(prod).subscribe(res => {
      this.product = res;
      if (this.product.id != "" || this.product.id != null || this.product.id != undefined) {
        if (this.file != null || this.file) {
          this.UploadImage(this.product.id);
        }
      }
      this.getallproducts();
      this.isShowAddPopup = false;
    });

  }

  file: File; isFileChanged: boolean;
  fileChange(event: any) {

    let fileList: FileList = event.target.files;
    this.file = fileList[0];
    if (this.file.type == "image/png" || this.file.type == "image/jpeg" || this.file.type == "image/jpg") {
      this.isFileChanged = true;
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.image = event.target.result;
      }
      reader.readAsDataURL(event.target.files[0]);
    }
    else {
      this.image = "../../../assets/assets/images/noImage.jpg";
    }
  }

  UploadImage(id: any) {
    debugger;
    let formData = new FormData();
    formData.append('uploadFile', this.file, this.file.name);

    this.productService.UploadImage(formData, id).subscribe((filePath: any) => {
      this.image = filePath.path;


    });
  }
}
