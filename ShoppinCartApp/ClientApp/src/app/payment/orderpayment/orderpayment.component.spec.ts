import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderpaymentComponent } from './orderpayment.component';

describe('OrderpaymentComponent', () => {
  let component: OrderpaymentComponent;
  let fixture: ComponentFixture<OrderpaymentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderpaymentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderpaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
