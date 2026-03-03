import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header implements OnInit {

  Admin = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    const rol = this.authService.traerRol();
    console.log(`rol llegado: ${rol}`);
    this.Admin = rol === 'Vendedor';

  }

  irLanding() {
    this.router.navigate(['/landing'])
  }

  irDashboard() {
    this.router.navigate(['/dashboard']);
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}