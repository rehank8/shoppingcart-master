import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharableService {

  constructor() { }

  itemCount = new BehaviorSubject<boolean>(false);

  sendData(value) {
    this.itemCount.next(value);
  }
}
