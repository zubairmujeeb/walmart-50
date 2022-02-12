import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductDetailRoutingModule } from './product-detail-routing.module';

import { ProductDetailComponent } from './product-detail.component'
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms'


@NgModule({
  declarations: [ProductDetailComponent],
  imports: [
    CommonModule,
    ProductDetailRoutingModule,
    FormsModule,
    SharedModule
  ]
})
export class ProductDetailModule { }
