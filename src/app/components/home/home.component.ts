import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  product: any

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.loadProducts()
  }

  loadProducts(){
    this.productService.getProduct().subscribe(resp => {
      alert(JSON.stringify(resp))
      this.product = resp
    })
  }

  get isLoggedIn(): boolean{
    return localStorage.getItem('userData') != null || localStorage.getItem('userData') != undefined
  }

  logOut(){
    localStorage.removeItem('userData')
  }

}
