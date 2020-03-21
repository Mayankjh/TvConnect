import { Component, OnInit,AfterViewInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from '../config.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit,AfterViewInit {

  constructor(private http: HttpClient, private config: Config) { }
profile={};
Userplan={};
vendor;
getUserInfo() {
  let userid = localStorage.getItem('userid')
  return this.http.get(this.config.path + '/users/' + userid);
}
  ngOnInit() {
     this.getUserInfo().subscribe((data)=>{
      //  console.log(data);
       this.profile['Firstname'] = data['firstName'];
       this.profile['Lastname'] = data['lastName'];
       this.profile['id'] = data['id'];
      //  console.log(data['planId']);
       this.getPlanByID(data['planId']).subscribe((data)=>{
        // console.log(data);
        this.Userplan['pack_Name'] = data['pack_Name'];
        this.Userplan['pack_Price'] = data['pack_Price'];
       this.getVendorByID(data['vendorId']).subscribe((data)=>{
        // console.log(data);
       this.vendor = data;
      });

      });
     });
    
  }
 ngAfterViewInit(){
 
 }
getPlanByID(id) {
  return this.http.get(this.config.path + '/api/plans/' +id );
}
getVendorByID(id) {
  return this.http.get(this.config.path + '/api/vendors/' +id );
}


}
