import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public getProduct(){
    return this.http.get('http://localhost:44366/api/product/getproduct')
  }

  getQuestionnaire(){
    return this.http.get('http://localhost:44366/api/product/getproductdetail')
  }

  addReview(request){
    return this.http.post('http://localhost:44366/api/product/addReview', request)
  }

  addProduct(request){
    return this.http.post('http://localhost:44366/api/product/create', request)
  }
}
