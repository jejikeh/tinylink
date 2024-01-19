import { HttpClient } from '@angular/common/http';
import { Injectable, computed, inject, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user: any = null;
  http: HttpClient = inject(HttpClient);

  constructor() {}

  loadUser() {
    const request = this.http.get<any>('https://localhost:4201/api/user');
    request.subscribe((user) => {
      this.user = user;
    });
  }

  login(loginForm: any) {
    return this.http
      .post<any>('https://localhost:4201/api/login', loginForm, {
        withCredentials: true,
      })
      .subscribe((_) => {});
  }

  register() {}

  logout() {
    return this.http
      .get<any>('https://localhost:4201/api/logout')
      .subscribe((_) => (this.user = null));
  }
}
