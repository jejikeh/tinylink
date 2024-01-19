import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../shared/data-access/auth.service';

@Component({
  selector: 'tinyurl-web-home',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>tinyurl-web</h1>
    <section>
      <nav>
        <ul>
          <li><a routerLink="home">Home</a></li>
          <li><a routerLink="login">login</a></li>
        </ul>
        <button (click)="logout()">Logout</button>
      </nav>
    </section>
  `,
})
export class HomeComponent {
  auth: AuthService = inject(AuthService);

  logout() {
    return this.auth.logout();
  }
}
