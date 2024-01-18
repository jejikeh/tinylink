import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'tinyurl-web-home',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>home</h1>
    <p>this is the home page</p>
  `,
})
export class HomeComponent {}
