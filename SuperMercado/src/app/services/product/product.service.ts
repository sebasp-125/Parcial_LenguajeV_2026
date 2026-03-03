import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environment/environment';
import { Zapato } from '../../model/interface/productInterface/product.interface';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<Zapato[]> {
    return this.http.get<Zapato[]>(`${this.apiUrl}/Product/AllProductos`);
  }

}