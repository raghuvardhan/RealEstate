import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-login-registration',
  templateUrl: './login-registration.component.html',
  styleUrls: ['./login-registration.component.css']
})
export class LoginRegistrationComponent implements OnInit {
  user: User = {id: 0, username: '', email: '', firstName: '', lastName: '', password: ''};

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  onLogin(): void {
    this.userService.login(this.user).subscribe(user => {
      // Handle successful login
    });
  }

  onRegister(): void {
    this.userService.register(this.user).subscribe(user => {
      // Handle successful registration
    });
  }
}
