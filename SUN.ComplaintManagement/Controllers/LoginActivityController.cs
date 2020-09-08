



using cbt.Interface.CBT;
using cbt.viewModel.User;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SUN.ComplaintManagement.Controllers
{
    [RoutePrefix("api/v1/LoginActivity")]
    // [Authorize]
    public class LoginActivityController : ApiController
    {
        private ILoginActivityRepository _repo;
        private JWTSettings _settings;
       // private IAuthRepository auth;
        public LoginActivityController(ILoginActivityRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetLoginActivity()
        {
            try
            {
                var data = _repo.GetLoginActivitys();

                if (!data.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{LoginActivityId}/LoginActivityId")]
        public HttpResponseMessage GetLoginActivity(int LoginActivityId)
        {
            try
            {
                var data = _repo.GetLoginActivity(LoginActivityId);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        //[HttpPost]
        //[Route("")]
        //public HttpResponseMessage AddLoginActivity(LoginActivityVM model)
        //{
        //    try
        //    {
        //        var response = _repo.AddLoginActivity(model);

        //        if (response == false)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = response });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
        //    }
        //}

        [HttpPut]
        [Route("")]
        public HttpResponseMessage UpdateLoginActivity(LoginActivityVM model)
        {
            try
            {
                var response = _repo.UpdateLoginActivity(model);

                if (response == false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = response });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{LoginActivityId}/LoginActivityId")]
        public HttpResponseMessage DeleteLoginActivity(int LoginActivityId)
        {
            try
            {
                var response = _repo.DeleteLoginActivity(LoginActivityId);

                if (response == false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "No record found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, result = response });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<HttpResponseMessage> Login(UserLoginVM user)
        {
            try
            {
                var keyValue = ConfigurationManager.AppSettings["SecurityKey"];

                var result = await _repo.Login(user);

                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = "Invalid username or password" });

                //    var claims = new[]
                //    {
                //    new Claim(ClaimTypes.NameIdentifier, result.Email),
                //    new Claim(ClaimTypes.Name, result.UserName)
                //};

                //var key = new SymmetricSecurityKey(Encoding.UTF8
                //    .GetBytes(keyValue));

                // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                // var tokenDescriptor = new SecurityTokenDescriptor
                // {
                //     Subject = new ClaimsIdentity(claims),
                //     Expires = DateTime.Now.AddDays(1),
                //     SigningCredentials = creds
                // };

                // var tokenHandler = new JwtSecurityTokenHandler();

                //var token = tokenHandler.CreateToken(tokenDescriptor);

                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, auth = result });
                // return Request.CreateResponse(HttpStatusCode.OK, new { success = true });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = false, message = ex.Message });
            }

        }
    }
}



     
