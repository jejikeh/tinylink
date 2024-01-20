import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  http: HttpClient = inject(HttpClient);

  constructor() {}

  login(loginForm: any) {
    const request = this.http
      .post('https://localhost:3201/api/login', loginForm, {
        withCredentials: true,
      })
      .subscribe((_) => {});
  }

  logout() {
    return this.http.post('/api/test', {});
  }
}
