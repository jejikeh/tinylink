import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from 'src/app/shared/data-access/auth.service';

@Component({
  selector: 'tinyurl-web-login',
  standalone: true,
  imports: [CommonModule],
  providers: [AuthService],
  template: `
    <section>
      <div>
        <form>
          <input [value]="username" />
          <input [value]="password" />
          <button (click)="login()">Login</button>
        </form>
      </div>
    </section>
  `,
})
export class LoginComponent {
  constructor(private auth: AuthService) {}

  username: any = '';
  password: any = '';

  login() {
    return this.auth.login({
      username: this.username,
      password: this.password,
    });
  }
}
