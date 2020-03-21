import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PlanService {

  constructor() { }
data;  
 Planset(plan) {      
    this.data = plan;
  }  
  
  Vendorget() {  
    return this.data;  
  } 
}
