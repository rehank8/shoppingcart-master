import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterusersComponent } from './registerusers.component';

describe('RegisterusersComponent', () => {
  let component: RegisterusersComponent;
  let fixture: ComponentFixture<RegisterusersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterusersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
