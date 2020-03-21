import { Component, OnInit } from '@angular/core';
import{PlanService} from '../plan/plan.service'
import {VendorService} from '../vendor/vendor.service'
@Component({
  selector: 'app-plan-detail',
  templateUrl: './plan-detail.component.html',
  styleUrls: ['./plan-detail.component.css']
})
export class PlanDetailComponent implements OnInit {

  constructor(private PlanService: PlanService,private VendorService: VendorService) { }
plandetail;
vendordetail;
channels;
channels1;

  ngOnInit() {
    this.plandetail = this.PlanService.Vendorget();
    // this.vendordetail = this.VendorService.Planget();
    console.log("vendor details",this.vendordetail);
    // console.log(this.plandetail.channel[0].channel_Name)
    this.channels = this.plandetail.channel;
    // this.channels1 = this.vendordetail.channel;

    // console.log(this.channels)
   
  }
  

}
