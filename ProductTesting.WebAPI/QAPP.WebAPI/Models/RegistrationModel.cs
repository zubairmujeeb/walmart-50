using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAPP.WebAPI.Models
{
    public class RegistrationModel
    {
        public long IdentityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? IdentityType { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetProfileRequest
    {
      public string Email { get; set; }
    }
}
