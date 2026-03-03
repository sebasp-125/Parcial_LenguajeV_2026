import { inject, Injectable, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
import { Observable } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';
import { environment } from '../../../environment/environment';
import { LoginResponse } from '../../model/interface/loginInterface/loginResponse.interface';
import { LoginRequest } from '../../model/interface/loginInterface/loginRequest.interface';
import { Router } from '@angular/router';


@Injectable({ providedIn: 'root'})
export class AuthService {

  private readonly tokenKey = 'token';
  private readonly apiUrl = environment.apiUrl;
  private platformId = inject(PLATFORM_ID);

  constructor(private http: HttpClient, private router: Router) {}

  login(data: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/Auth/login`, data);
  }

  agregarToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  traerToken() {
  if (isPlatformBrowser(this.platformId)) {
    const token = localStorage.getItem(this.tokenKey);
    console.log('tokensito:', token);
    return localStorage.getItem(this.tokenKey);
  }
  return null;
}


  traerRol(): string | null {
    const token = this.traerToken();
    if (!token) return null;

    const decoded: any = jwtDecode(token);
    return decoded['role'] || null;
  }


  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  isLogged(): boolean {
    const token = this.traerToken();
    if (!token) return false;

    try {
      const decoded: any = jwtDecode(token);
      const exp = decoded.exp * 1000; 
      return Date.now() < exp;
    } catch {
      return false;
    }
  }
}