using ProductTesting.WebAPI.Models;
using QAPP.WebAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ProductTesting.WebAPI.Services
{
    public class ProductService
    {

        public ProductWithQuestionnaireResponse GetProductQuestionnaire()
        {
            using (var context = new ProductTestingEntities())
            {
                var maxDate = context.Products.Max(p => p.CreatedDateTime);
                var ProductWithQuestionnaire = context.Products.Where(pq => pq.CreatedDateTime == maxDate).Select(q => new ProductWithQuestionnaireResponse
                {
                  ProductID = q.ProductID,
                  Title = q.Title,
                  Description = q.Description,
                  Photo = q.PhotoPath,
                  CreatedDateTime = q.CreatedDateTime,
                  Price = q.Price,
                  ProductQuestions = q.ProductQuestions.Select(x => new QuestionnaireData {
                                        QuestionID = x.QuestionID,
                                        ProductID = x.ProductID,
                                        QuestionStatement = x.Statement,
                                        Image = x.Photo,
                                        Answer = x.Answer
                                          }).ToList()

                  }).FirstOrDefault();

                if (ProductWithQuestionnaire == null)
                {
                    throw new Exception("No questionnaire found");
                }
                return ProductWithQuestionnaire;
            }

        }

        public void CreateProductQuestionnaire(CreateProductRequest request)
        {
            using(var context = new ProductTestingEntities())
            {
                var checkProduct = context.Products.Where(p => p.ProductID == request.ProductID);

                if (checkProduct == null)
                {
                  var product = new Product
                  {
                    Title = request.Title,
                    Description = request.Description,
                    PhotoPath = request.Photo,
                    Price = request.Price,
                    CreatedDateTime = DateTime.UtcNow
                  };
                  var newProduct = context.Products.Add(product);
                  context.SaveChanges();
                  request.ProductID = newProduct.ProductID;

                }

                var questionnaire = context.ProductQuestions.ToList();


                foreach (var questionItem in request.ProductQuestions)
                {
                    var questionCheck = questionnaire.Find(x => x.Statement == questionItem.QuestionStatement);
                    if (questionCheck != null)
                    {
                        continue;
                    }
                    var question = new ProductQuestion
                    {
                        ProductID = request.ProductID,
                        Statement = questionItem.QuestionStatement,
                        Photo = questionItem.Image,
                        Answer = questionItem.Answer
                    };
                    context.ProductQuestions.Add(question);

                };
                context.SaveChanges();
            }
        }

        public GetProductResponse GetProduct()
        {
          using (var context = new ProductTestingEntities())
          {
            var maxDate = context.Products.Max(p => p.CreatedDateTime);
            var ProductResponse = context.Products.Where(pq => pq.CreatedDateTime == maxDate).Select(q => new GetProductResponse
            {
              Title  = q.Title,
              Description = q.Description,
              Price = q.Price,
              Photo = q.PhotoPath,
              CreatedDateTime = q.CreatedDateTime
            }).FirstOrDefault();

            if (ProductResponse == null)
            {
              throw new Exception("No Product Found");
            }

            return ProductResponse;
          }
        }

        public void ReviewProduct(ReviewProductRequest request)
        {
          using (var context = new ProductTestingEntities())
          {
            var checkProduct = context.Products.Where(x => x.ProductID == request.ProductID).FirstOrDefault();

            if (checkProduct == null)
            {
              throw new Exception("No Product Found");
            }
            var questionIds = request.ResponseList.Select(x => x.QuestionID).ToList();
            var checkAlreadyAttempted = context.QuestionnaireResponses.Where(x => questionIds.Contains(x.QuestionID)).FirstOrDefault();

            if (checkAlreadyAttempted != null)
            {
              throw new Exception("Already Attempted");
            }

            foreach(var response in request.ResponseList)
            {
              var addResponse = new QuestionnaireResponse
              {
                QuestionID = response.QuestionID,
                RespondantID = request.RespondantID,
                Response = response.Answer
              };
              context.QuestionnaireResponses.Add(addResponse);

            }
            context.SaveChanges();
            var respondantEmail = context.Identities.Where(x => x.IdentityID == request.RespondantID).Select(y => y.Email).FirstOrDefault();
          }

        }


    }
    public class SendReviewAttemptedEmailRequest
    {
      public string Email { get; set; }
      public string ProductTitle { get; set; }
    }
}
