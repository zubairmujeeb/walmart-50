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
    
    public partial class QuestionnaireResponse
    {
        public long QuestionnaireResponse1 { get; set; }
        public long QuestionID { get; set; }
        public long RespondantID { get; set; }
        public bool Response { get; set; }
    
        public virtual Identity Identity { get; set; }
        public virtual ProductQuestion ProductQuestion { get; set; }
    }
}