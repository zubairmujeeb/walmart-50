import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { IdentityService } from 'src/app/services/identity.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  title = ''
  firstName = ''
  lastName = ''
  email = ''
  country = ''
  mobileNo = ''
  dateOfBirth = ''
  password = ''
  showDD = false
  showModal = false
  showModalTab2 = false;
  emailError: boolean = false;

  product: any
  acceptedTerms: any

  constructor(private productService: ProductService,
    private identityService: IdentityService,
    private router: Router) { }

  ngOnInit(): void {
  }

  loadProducts(){
    this.productService.getProduct().subscribe(resp => {
      alert(JSON.stringify(resp))
      this.product = resp
    })
  }

  switchMenuDD(){
    this.showDD = !this.showDD
  }

  showOrHideModal(){
    if(!this.acceptedTerms){
      return
    }
    this.showModal = !this.showModal
  }

  get validEmail(){

    var filter = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;
    return String(this.email).search (filter) != -1;

  }

  showTab2(){
    if(this.validEmail){
      this.identityService.getProfile(this.email).subscribe(resp => {
        if(resp){
          localStorage.setItem('userData', JSON.stringify(resp))
          this.router.navigate([`/product-campaigns`])
        }
      }, err => {
        alert("Failed Login")
        console.log("Failed Login",(err))
        if(err.error.ExceptionMessage == "User Does Not exists"){
          this.emailError = false
          this.showModalTab2 = !this.showModalTab2

        }

      })
      return
    }

    this.emailError = true
  }

  signUp(){
    let data = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      country: this.country,
      mobileNo: this.mobileNo,
      dateOfBirth: this.dateOfBirth,
      password: this.password
    }
    this.identityService.signUp(data).subscribe(resp => {
      this.identityService.getProfile(this.email).subscribe(resp => {
        if(resp){
          localStorage.setItem('userData', JSON.stringify(resp))
          this.router.navigate([`/product-campaigns`])
        }
      }, err => {
        alert("Failed Get Profile")
        console.log("Failed Get Profile",(err))
      })
    }, err => {
      alert("Failed SignUp")
      console.log("Failed SignUp",(err))
    })
  }

}
