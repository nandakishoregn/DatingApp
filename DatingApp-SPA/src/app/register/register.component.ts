import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() registerCancelledEvent = new EventEmitter();
  model: any = {};
  constructor(private authService: AuthService, private alertifyService : AlertifyService) { }

  ngOnInit() {
  }

  register() {
    console.log(this.model);
    this.authService.register(this.model).subscribe(
      () => {
        this.alertifyService.success('Registration Successfull');
      }, error => {
        this.alertifyService.error(error);
      }
    );
  }

  cancel() {
    this.registerCancelledEvent.emit(false);
    console.log('cancelled');
  }
}
