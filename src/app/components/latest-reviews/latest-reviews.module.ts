import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LatestReviewsRoutingModule } from './latest-reviews-routing.module';

import { LatestReviewsComponent } from './latest-reviews.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [LatestReviewsComponent],
  imports: [
    CommonModule,
    LatestReviewsRoutingModule,
    SharedModule
  ]
})
export class LatestReviewsModule { }
