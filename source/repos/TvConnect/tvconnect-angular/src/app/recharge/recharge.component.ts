import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2'


declare var $:any;
@Component({
  selector: 'app-recharge',
  templateUrl: './recharge.component.html',
  styleUrls: ['./recharge.component.css']
})
export class RechargeComponent implements OnInit {
Vendors;
plans

selectedvendor: any;
selectedplan: any;
packprice;
months: any;
Amount: any;
userid = localStorage.getItem('userid');
  constructor(private router: Router,private RestService: RestService) { }

  ngOnInit() {
    this.RestService.getVendors().subscribe((data)=>{
      this.Vendors = data;
      // console.log(data[0]['plans'][0]);
      // console.log(data);
    });
    $(document).ready(function(){
      $('select').not('.disabled').formSelect();
  });
 
      $(document).ready(function(){
        $('.modal').modal();
      });

   
  }


GetTotal() {
     this.Amount = this.packprice * parseInt(this.months);
    //  console.log(this.Amount)
    //  console.log(parseInt(this.months),this.packprice)
 } 

getSelectedvendor(){
    console.log(JSON.stringify(this.selectedvendor));
    this.populate(this.selectedvendor)
 }
 getSelectedplan(){
  console.log(JSON.stringify(this.selectedplan));
  this.packprice = this.selectedplan.pack_Price;
 }

 
  populate(vendor){
    this.plans = vendor;
    console.log(this.plans)
  }
  Recharge(){
    $('#modal1').modal('open');
  }
  postRecharge(){
    this.router.navigate(['/user']);
    Swal.fire({
      icon: "success",
    title:'Recharge In Process...'});}
}
