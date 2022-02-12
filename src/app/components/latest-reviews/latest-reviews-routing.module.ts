import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LatestReviewsComponent } from './latest-reviews.component';

const routes: Routes = [
  {path: '', component: LatestReviewsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LatestReviewsRoutingModule { }
