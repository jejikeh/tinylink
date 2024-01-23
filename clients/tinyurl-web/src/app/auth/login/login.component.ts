import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <section>
      <form>
        <label for="username">Username</label>
        <input
          for="username"
          type="text"
          name="username"
          [formControl]="username"
        />
        <label for="email">Email</label>
        <input id="email" type="text" name="email" [formControl]="email" />
        <label for="password">Password</label>
        <input
          id="password"
          type="password"
          name="password"
          [formControl]="password"
        />
      </form>
      <button (click)="login()">Login</button>
    </section>
  `,
})
export class LoginComponent {
  auth: AuthService = inject(AuthService);

  email = new FormControl('');
  password = new FormControl('');
  username = new FormControl('');

  login() {
    return this.auth.login({
      email: this.email.value,
      password: this.password.value,
      username: this.username.value,
    });
  }
}
