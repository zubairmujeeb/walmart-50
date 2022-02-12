import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  newQuestion: any = {
   questionStatement: '',
   quizQuestionOptions: [],
  }
  quizQuestions: any[] = []
  answerChoices: any[] = []
  newChoice: any
  correctAnswer: string
  productTitle: string
  productDescription: string
  productPrice: string
  currentUser: any
  product: any
  productQuestions: any
  productId: any;

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit(): void {

    this.getProductQuestionnaire()
  }

  getProductQuestionnaire(){
    this.productService.getQuestionnaire().subscribe((resp:any) => {
      console.log("questionnaire ", resp)
      this.product = resp
      this.productTitle = this.product.Title
      this.productPrice = this.product.Price
      this.productDescription = this.product.Description
      this.productId = this.product.ProductID
      this.quizQuestions = resp.ProductQuestions
    },err => {
      console.log("failed to get question")
    })
  }
  public addChoice(): void {
    if (this.newChoice != '') {
      this.answerChoices.push({
        optionStatement: this.newChoice
      })
      this.newChoice = ''
    }
  }

  public removeItem(index): void {
    this.answerChoices.splice(index, 1)
  }

  public removeQuestion(index): void {
    this.quizQuestions.splice(index, 1)
  }

  public addQuestion(): void {
    if (this.newQuestion) {
      this.answerChoices.forEach(option => {
        option.isCorrect = option.optionStatement === this.correctAnswer;
      })
      this.newQuestion.quizQuestionOptions = this.answerChoices
      this.quizQuestions.push({
        QuestionStatement: this.newQuestion.questionStatement,
        image: '',
        answer: this.correctAnswer.toLowerCase() == 'yes' || this.correctAnswer.toLowerCase() == 'true'? true: false
      })

      this.newQuestion = {
        QuestionStatement: '',
        quizQuestionOptions: [],
       }
      this.answerChoices = []
      this.correctAnswer = null
    }
  }


  public saveQuizQuestions(): void {
    let request = {
      productId: this.productId,
      title: this.productTitle,
      description: this.productDescription,
      price: this.productPrice,
      photo: '',
      productQuestions: this.quizQuestions,
    }
    console.log("request ", request)
    this.productService.addProduct(request).subscribe(resp => {
      alert("Product Created")
    }, err => {
      alert("Failed Product add")
    })

  }

}
