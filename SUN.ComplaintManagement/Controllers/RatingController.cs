



using cbt.Interface.CBT;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUN.ComplaintManagement.Controllers
{
    [RoutePrefix("api/v1/Rating")]
    // [Authorize]
    public class RatingController : ApiController
    {
        private IRatingRepository _repo;
        public RatingController(IRatingRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetRating()
        {
            try
            {
                var data = _repo.GetRatings();

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
        [Route("{RatingId}/RatingId")]
        public HttpResponseMessage GetRating(int RatingId)
        {
            try
            {
                var data = _repo.GetRating(RatingId);

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

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddRating(RatingVM model)
        {
            try
            {
                var response = _repo.AddRating(model);

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
        [Route("")]
        public HttpResponseMessage UpdateRating(RatingVM model)
        {
            try
            {
                var response = _repo.UpdateRating(model);

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
        [Route("{RatingId}/RatingId")]
        public HttpResponseMessage DeleteRating(int RatingId)
        {
            try
            {
                var response = _repo.DeleteRating(RatingId);

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
    }
}



     
