import { Component, afterNextRender, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from './auth/services/auth.service';
import { environment } from '../environments/environment';
import { platform } from 'os';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  template: `
    <section>
      <div class="navbar">
        <nav>
          <ul>
            <li>
              <a
                routerLink="/home"
                routerLinkActive="active"
                ariaCurrentWhenActive="page"
                >Home</a
              >
            </li>
            <li>
              <a
                routerLink="/auth/register"
                routerLinkActive="active"
                ariaCurrentWhenActive="page"
                >Register</a
              >
            </li>
            <li>
              <a
                routerLink="/auth/login"
                routerLinkActive="active"
                ariaCurrentWhenActive="page"
                >Login</a
              >
            </li>
            <li>
              <button (click)="logout()">Logout</button>
            </li>
          </ul>
        </nav>
      </div>
      <div class="container">
        <p>{{ auth.user.id }}</p>
        <router-outlet></router-outlet>
      </div>
    </section>
  `,
})
export class AppComponent {
  auth: AuthService = inject(AuthService);
  test: any = 'test';

  constructor() {
    afterNextRender(() => {
      this.auth.loadUser();
    });
  }

  logout() {
    this.auth.logout();
  }
}
