import { Injectable } from '@angular/core';
import {Product} from '../models/product';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, map, tap} from 'rxjs/operators';


@Injectable()
export class ProductService {

  constructor(private http: HttpClient) { }

private urlGetProdutos = 'http://localhost:30175/produtos/listar';

private handleError <T>( operation = 'operation', result: T ){
  return (error: any) : Observable<T> => {
    console.error(error, `Operation: ${operation}`);

    return of(result as T);
  }
}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.urlGetProdutos)
            .pipe(
              tap(products => console.log('Fetched products')),
              catchError(this.handleError('getProducts', []))
            )
  }
}
