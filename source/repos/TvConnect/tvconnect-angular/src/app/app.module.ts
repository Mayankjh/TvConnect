import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthInterceptor } from './auth/auth.interceptor';
import { AuthModule } from './auth/auth.module';
import { AuthService } from './auth/auth.service';
import { AuthGuard } from './auth/auth-guard.service';
import { Config } from './config.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AuthComponent } from './auth/auth.component';
import { SigninComponent } from './auth/signin/signin.component';
import { VendorComponent } from './vendor/vendor.component';
import { PlanComponent } from './plan/plan.component';
import { PlanDetailComponent } from './plan-detail/plan-detail.component';
import { RechargeComponent } from './recharge/recharge.component';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user/user.component';
import { VendorplansComponent } from './vendorplans/vendorplans.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    FooterComponent,
    HomeComponent,
    AuthComponent,
    VendorComponent,
    PlanComponent,
    PlanDetailComponent,
    RechargeComponent,
    UserComponent,
    VendorplansComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    AuthModule,
  ],
  providers: [
    AuthService,
    AuthGuard,
    Config,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
