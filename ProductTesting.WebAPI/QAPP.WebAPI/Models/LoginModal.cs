using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAPP.WebAPI.Models
{
    public class LoginModal
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public long IdentityId { get; set; }
        public string Token { get; set; }
    }
}