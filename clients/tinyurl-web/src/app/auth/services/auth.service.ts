import { HttpClient } from '@angular/common/http';
import { Injectable, afterNextRender, inject } from '@angular/core';
import { environment } from '../../../environments/environment';
import { User } from '../common/models/auth/user.model';
import { ClaimResponse } from '../common/responses/auth/claim.response';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public http: HttpClient = inject(HttpClient);

  // @Cleanup: signal here
  public user: User = {
    id: '',
    email: '',
    username: '',
  };

  constructor() {}

  loadUser() {
    return this.http
      .get<ClaimResponse[]>(environment.backendUrl + '/api/user', {
        withCredentials: true,
      })
      .subscribe((data) => {
        // @Cleanup: maybe create a new model for this
        data.forEach((claim) => {
          if (claim.type === 'user_id') {
            this.user.id = claim.value;
          }
          if (claim.type === 'user_email') {
            this.user.email = claim.value;
          }
          if (claim.type === 'user_username') {
            this.user.username = claim.value;
          }
        });

        console.log(this.user);
      });
  }

  login(loginForm: any) {
    const request = this.http
      .post(environment.backendUrl + '/api/login', loginForm, {
        withCredentials: true,
      })
      .subscribe((data) => {
        this.loadUser();
      });
  }

  logout() {
    return this.http
      .post(
        environment.backendUrl + '/api/logout',
        {},
        {
          withCredentials: true,
        }
      )
      .subscribe(() => {
        this.loadUser();
      });
  }
}
