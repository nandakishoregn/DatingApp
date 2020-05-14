import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedInUser: string;
  constructor(private authService: AuthService, private alertifyService: AlertifyService, private router: Router) {
    ;
  }

  ngOnInit() {

  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertifyService.success('User logged in Successfully');
    }, error => {
      this.alertifyService.error('Failed cannot login');
    }, () => {
      this.router.navigate(['/members']);
    });
  }

  loggedIn() {
    const isLoggedIn = this.authService.loggedIn();
    if (isLoggedIn) {
      this.loggedInUser = this.authService.loggedInUserName();
    }
    return isLoggedIn;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out successfully');
    this.router.navigate(['/home']);
  }
}
