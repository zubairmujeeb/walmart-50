//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QAPP.WebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductQuestion()
        {
            this.QuestionnaireResponses = new HashSet<QuestionnaireResponse>();
        }
    
        public long QuestionID { get; set; }
        public long ProductID { get; set; }
        public string Statement { get; set; }
        public string Photo { get; set; }
        public Nullable<bool> Answer { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionnaireResponse> QuestionnaireResponses { get; set; }
    }
}
