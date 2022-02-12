import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'product-detail', loadChildren: () => import('./components/product-detail/product-detail.module').then(m => m.ProductDetailModule)},
  {path:'product-campaigns', loadChildren: () => import('./components/campaigns/campaigns.module').then(m => m.CampaignsModule)},
  {path:'about-us', loadChildren: () => import('./components/about-us/about-us.module').then(m => m.AboutUsModule)},
  {path:'login', loadChildren: () => import('./components/login/login.module').then(m => m.LoginModule)},
  {path:'reviews', loadChildren: () => import('./components/reviews/reviews.module').then(m => m.ReviewsModule)},
  {path:'latest-reviewers', loadChildren: () => import('./components/latest-reviews/latest-reviews.module').then(m => m.LatestReviewsModule)},
  {path:'category', loadChildren: () => import('./components/category/category.module').then(m => m.CategoryModule)},
  {path:'admin-dashboard', loadChildren: () => import('./components/admin-dashboard/admin-dashboard.module').then(m => m.AdminDashboardModule)},
  {path:'thankyou', loadChildren: () => import('./components/thankyou/thankyou.module').then(m => m.ThankyouModule)},



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
