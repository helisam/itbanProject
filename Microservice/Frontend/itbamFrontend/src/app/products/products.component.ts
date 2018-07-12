import { Component, OnInit } from '@angular/core';
import {Product } from '../models/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'itbam-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[];

  produtoSelecionado: Product

  constructor(private productService: ProductService) { }

  aoSelecionarProduto(product){
    this.produtoSelecionado = product;
  }

  ngOnInit() {
      //this.getProducts();
      this.productService.getProducts()
      .subscribe((products: Product[]) => {this.products = products});
  }

  getProducts(): Product[] {
    const products = this.productService.getProducts()
    .subscribe((products: Product[]) => {this.products = products});
    //.subscribe(products => console.log(products));
    //.subscribe(products => this.products = products);

    console.log(products);
  }

}
