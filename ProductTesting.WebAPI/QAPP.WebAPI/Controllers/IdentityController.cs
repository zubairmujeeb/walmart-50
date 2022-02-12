using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using QAPP.WebAPI.Models;
using ProductTesting.WebAPI.Services;

namespace ProductTesting.WebAPI.Controllers
{
    [RoutePrefix("api/identity")]
    public class IdentityController : ApiController
    {
        IdentityService identityService = new IdentityService();

        [HttpPost]
        [Route("register")]
        public string Register([FromBody] RegistrationModel request)
        {
            return identityService.Register(request);
        }

        [HttpPost]
        [Route("login")]
        public LoginResponse Login([FromBody] LoginModal request)
        {
            return identityService.Login(request);
        }

        [HttpPost]
        [Route("getprofile")]
        public GetProfileDataResponse GetUserProfile(
            [FromBody]
            GetProfileRequest request
            )
        {
            return identityService.GetProfileData(request.Email);
        }
    }
}
