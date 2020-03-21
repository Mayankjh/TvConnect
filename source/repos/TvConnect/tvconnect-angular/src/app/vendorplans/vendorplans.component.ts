import { Component, OnInit } from '@angular/core';
import{VendorService} from '../vendor/vendor.service'
import { HttpClient } from '@angular/common/http';
import { Config } from '../config.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vendorplans',
  templateUrl: './vendorplans.component.html',
  styleUrls: ['./vendorplans.component.css']
})
export class VendorplansComponent implements OnInit {

  constructor(private router: Router,private VendorService: VendorService,private http: HttpClient, private config: Config) { }
  plandetail={};
  channels;
  ngOnInit() {
    this.plandetail = this.VendorService.Planget();
    console.log(this.plandetail)
  }
  getPlanByID(id) {
    return this.http.get(this.config.path + '/api/plans/' +id );
  }
  ShowPlans(id){
    let plan;
    this.getPlanByID(id).subscribe((data)=>{
    plan = data;
    }); 
    this.VendorService.Vendorset(plan);
    this.router.navigate(['/plandetail']);
   }
}
