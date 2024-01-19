import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './shared/data-access/auth.service';

@Component({
  standalone: true,
  imports: [RouterOutlet],
  providers: [AuthService],
  selector: 'tinyurl-web-root',
  template: `<router-outlet></router-outlet> `,
})
export class AppComponent {}
