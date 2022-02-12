import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReviewsRoutingModule } from './reviews-routing.module';

import { ReviewsComponent } from './reviews.component'
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [ReviewsComponent],
  imports: [
    CommonModule,
    ReviewsRoutingModule,
    SharedModule
  ]
})
export class ReviewsModule { }
