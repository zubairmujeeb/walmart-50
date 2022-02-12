import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-thankyou',
  templateUrl: './thankyou.component.html',
  styleUrls: ['./thankyou.component.scss']
})
export class ThankyouComponent implements OnInit {
  product = {
    title: ''
  }

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProduct()
  }

  getProduct(){
    this.productService.getProduct().subscribe((resp:any) => {
      this.product.title = resp.Title
    })
  }

}
