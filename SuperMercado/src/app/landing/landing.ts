import { Component, OnInit, inject, PLATFORM_ID, ChangeDetectorRef } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { AuthService } from '../services/auth/auth.service';
import { ProductService } from '../services/product/product.service';
import { Zapato } from '../model/interface/productInterface/product.interface';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './landing.html',
  styleUrl: './landing.css',
})
export class Landing implements OnInit {

  productos: Zapato[] = [];
  loading = false;
  isLogged = false;
  isBrowser = false;
  isAdmin = false;

  private platformId = inject(PLATFORM_ID);

  constructor(
    private productService: ProductService,
    private authService: AuthService,
    private cdr: ChangeDetectorRef
  ) {}

 ngOnInit(): void {
  if (isPlatformBrowser(this.platformId)) {
    this.isBrowser = true;
    this.isLogged = this.authService.isLogged();

    if (this.isLogged) {
      const role = this.authService.traerRol();
      this.isAdmin = role === 'Vendedor';
      this.cargarProductos();
    }
  }
}

  cargarProductos(): void {
    this.loading = true;

    this.productService.getAllProducts().subscribe({
      next: (res) => {
        this.productos = res;
        this.loading = false;
        console.log(this.productos);
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Error cargando productos:', err);
        this.loading = false;
        this.cdr.detectChanges();
      }
    });
  }

}