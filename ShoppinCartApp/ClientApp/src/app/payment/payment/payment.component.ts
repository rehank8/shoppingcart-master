import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  public showSuccess: boolean = false;
  public showCancel: boolean = false;
  public showError: boolean = false;
  constructor() { }

  ngOnInit() {
  }

}
