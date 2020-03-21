import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import {VendorService} from './vendor.service'
import { Router } from '@angular/router';


@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent implements OnInit {

  constructor(private router: Router,private RestService: RestService,private VendorService: VendorService) { }
  Vendors;
  ngOnInit() {
    this.RestService.getVendors().subscribe((data)=>{
      this.Vendors = data;
      console.log(data)
    });
  }
  ShowPlans(vendors){
    this.VendorService.Vendorset(vendors);
    this.router.navigate(['/vendor/plandetail']);
   }

}
