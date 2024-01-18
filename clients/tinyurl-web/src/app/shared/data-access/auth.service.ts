import { HttpClient } from '@angular/common/http';
import { Injectable, computed, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

export type AuthUser = { id: string } | null | undefined;

interface AuthState {
  user: AuthUser;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  // private auth = inject(AUTH_SERVICE?)

  // sources
  private user$ = null;

  // state
  private state = signal<AuthState>({
    user: undefined,
  });

  // selectors
  user = computed(() => this.state().user);

  constructor(private http: HttpClient) {}

  loadUser() {}

  login() {}

  register() {}
}
