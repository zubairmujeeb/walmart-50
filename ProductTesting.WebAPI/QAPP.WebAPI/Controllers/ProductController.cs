using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QAPP.WebAPI.Models;
using ProductTesting.WebAPI.Services;
using ProductTesting.WebAPI.Models;

namespace ProductTesting.WebAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
    ProductService productService = new ProductService();

        [Route("getProduct")]
        [HttpGet]
        public GetProductResponse GetProductList()
        {
            Request.Headers.Contains("JWT");
            return productService.GetProduct();
        }

        //[Authorize]
        [Route("create")]
        [HttpPost]
        public void CreateProductQuestionnaire(
            [FromBody]
            CreateProductRequest request)
        {
           productService.CreateProductQuestionnaire(request);
        }

        [Route("getproductdetail")]
        [HttpGet]
        public ProductWithQuestionnaireResponse GetProductDetail()
        {
            return productService.GetProductQuestionnaire();
        }

        [Route("addReview")]
        [HttpPost]
        public void SubmitProductReview(
          [FromBody]
          ReviewProductRequest request
          )
        {
           productService.ReviewProduct(request);
        }

    }
}
