using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QAPP.WebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNet.Identity;
using QAPP.WebAPI;

namespace ProductTesting.WebAPI.Services
{
    public class IdentityService
    {
        PasswordHasher ph = new PasswordHasher();

        public string Register(RegistrationModel request)
        {
            using (var context = new ProductTestingEntities())
            {
                var user = context.Identities.Where(u => u.Email == request.Email).FirstOrDefault();
                if (user != null)
                {
                    throw new Exception("UserName Already Exist");
                }
                var Identity = new Identity
                {
                    Firstname = request.FirstName,
                    Lastname = request.LastName,
                    Title = request.Title,
                    Email = request.Email,
                    Mobile = request.MobileNo,
                    Country = request.Country,
                    DateOfBirth = request.DateOfBirth,
                    Password = GenerateHashedText(request.Password)
                };
                context.Identities.Add(Identity);
                context.SaveChanges();

                return GenerateToken(request.Email);
            }
        }

        public LoginResponse Login(LoginModal request)
        {
            using (var context = new ProductTestingEntities())
            {
                var user = context.Identities.Where(u => u.Title == request.UserName).FirstOrDefault();

                if (user == null || !VerifyHashedText(request.Password, user.Password))
                {
                    throw new Exception("UserName Or Password InCorrect");
                }

                var jwt_token = GenerateToken(user.Email);

                var response = new LoginResponse()
                {
                    IdentityId = user.IdentityID,
                    Token = jwt_token
                };
                return response;
            }

        }

        public GetProfileDataResponse  GetProfileData(string email)
        {
            if (email == null)
            {
                throw new Exception("Email Required");
            }
            using(var context = new ProductTestingEntities())
            {
                var user = context.Identities.Where(u => u.Email == email).FirstOrDefault();

                if (user == null)
                {
                    throw new Exception("User Does Not exists");
                }

                var response = new GetProfileDataResponse()
                {
                    IdentityID = user.IdentityID,
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Title = user.Title,
                    Email = user.Email
                };

                return response;
            }
        }

        // Need to install package System.IdentityModel.Tokens.Jwt
        private string GenerateToken(string email)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddMinutes(60);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                email == "admin@prodtesting.com" ? new Claim(ClaimTypes.Role, "Admin"):
                    new Claim(ClaimTypes.Role, "User"),
                new Claim("Email", email)
            });

            const string sec = "my_secret_key_12345";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:44366/", audience: "http://localhost:44366/",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;

        }

        private string GetIdentityType(string userName)
        {
            using(var context = new ProductTestingEntities())
            {
                var identityType = context.Identities.Where(x => x.Email == userName)
                        .Select(u => u.Email)
                        .FirstOrDefault();

                return identityType;
            }
        }

        private string GenerateHashedText(string planText)
        {
            return ph.HashPassword(planText);
        }

        private bool VerifyHashedText(string plainText, string hashedText)
        {
            return ph.VerifyHashedPassword(hashedText, plainText) == PasswordVerificationResult.Success ;
        }
    }

    public enum Role
    {
        Student = 3,
        Teacher = 2
    }
}
