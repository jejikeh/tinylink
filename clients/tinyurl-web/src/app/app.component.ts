import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  imports: [RouterOutlet],
  selector: 'tinyurl-web-root',
  template: `<router-outlet></router-outlet>`,
})
export class AppComponent {}
