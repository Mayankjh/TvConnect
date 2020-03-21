import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestService } from '../rest.service';
import {PlanService} from './plan.service';
import { from } from 'rxjs';

@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.css']
})
export class PlanComponent implements OnInit {

  constructor(private router: Router,private RestService: RestService,private PlanService: PlanService) {
    
   }
   plans;
  ngOnInit() {
    this.RestService.getPlans().subscribe((data)=>{
      this.plans = data;
    });
  }

  ShowDetails(plan){
   this.PlanService.Planset(plan);
   this.router.navigate(['/plandetail']);
  }


}
