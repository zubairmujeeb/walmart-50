using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductTesting.WebAPI.Models
{

  public class CreateProductRequest
  {
    public long ProductID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Photo { get; set; }
    public List<QuestionnaireData> ProductQuestions { get; set; }

  }

  public class QuestionnaireData
  {
    public long QuestionID { get; set; }
    public long ProductID { get; set; }
    public string QuestionStatement { get; set; }
    public string Image { get; set; }
    public Nullable<bool> Answer { get; set; }

  }

  public class ProductWithQuestionnaireResponse
  {
    public long ProductID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Photo { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public List<QuestionnaireData> ProductQuestions { get; set; }
  }

  public class GetProductResponse
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Photo { get; set; }
    public DateTime? CreatedDateTime { get; set; }
  }

  public class ReviewProductRequest
  {
    public long ProductID { get; set; }
    public long RespondantID { get; set; }
    public List<ReviewResponseList> ResponseList { get; set; }
  }

  public class ReviewResponseList
  {
    public long QuestionID { get; set; }
    public bool Answer { get; set; }
  }
}
