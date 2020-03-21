import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService: AuthService) { }

  isAuthenticated() {
    return this.authService.isAuthenticated();
  }

  ngOnInit() {
  }

  logout(){
    this.authService.logout();
    Swal.fire("Logout Successful!")
  }

}
