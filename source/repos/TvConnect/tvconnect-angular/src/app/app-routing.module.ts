import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import{HomeComponent} from './home/home.component'
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { PlanComponent } from './plan/plan.component';
import { VendorComponent } from './vendor/vendor.component';
import { PlanDetailComponent } from './plan-detail/plan-detail.component';
import { RechargeComponent } from './recharge/recharge.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './auth/auth-guard.service';
import { VendorplansComponent } from './vendorplans/vendorplans.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
    {path: 'signin',component:SigninComponent},
    {path: 'signup',component:SignupComponent},
    {path: 'plans',component:PlanComponent},
    {path:'vendors',component:VendorComponent},
    {path:'plandetail',component:PlanDetailComponent},
    {path:'recharge',component:RechargeComponent,canActivate: [AuthGuard]},
    {path:'user',component:UserComponent,canActivate: [AuthGuard]},
    {path:'vendor/plandetail',component:VendorplansComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
