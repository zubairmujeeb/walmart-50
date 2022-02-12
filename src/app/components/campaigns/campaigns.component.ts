import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from 'src/app/services/identity.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-campaigns',
  templateUrl: './campaigns.component.html',
  styleUrls: ['./campaigns.component.scss']
})
export class CampaignsComponent implements OnInit {
  user = {
    firstName: '',
    userId: ''
  }
  product: any
  productQuestions: any

  constructor(private productService: ProductService,
    private identityService: IdentityService,
    private router: Router) { }

  ngOnInit(): void {
    let user = JSON.parse(localStorage.getItem('userData'))
    this.user.firstName = user.FirstName
    this.user.userId = user.IdentityID
    if(!this.user){
      this.router.navigate([`/`])
    }
    this.getProductQuestionnaire()
  }

  getProductQuestionnaire(){
    this.productService.getQuestionnaire().subscribe((resp:any) => {
      console.log("questionnaire ", resp)
      this.product = resp
      this.productQuestions = resp.ProductQuestions
    },err => {
      console.log("failed to get question")
    })
  }

  submitReview(){
    let questionsList = this.productQuestions.map(pq => {return {
      questionID: pq.QuestionID,
      answer: pq.Answer

    }})
    let request = {
      productId: this.product.ProductID,
      respondantId: this.user.userId,
      responseList: questionsList

    }

    this.productService.addReview(request).subscribe(resp => {

    })
    this.router.navigate([`/thankyou`])

  }

}
