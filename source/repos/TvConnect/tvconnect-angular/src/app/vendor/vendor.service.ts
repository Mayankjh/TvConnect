import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  constructor() { }
  data;  
 Vendorset(plan) {      
    this.data = plan;
  }  
  
  Planget() {  
    return this.data.plans;  
  } 
}
