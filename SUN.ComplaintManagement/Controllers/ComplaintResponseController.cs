



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
    [RoutePrefix("api/v1/ComplaintResponse")]
    // [Authorize]
    public class ComplaintResponseController : ApiController
    {
        private IComplaintResponseRepository _repo;
        public ComplaintResponseController(IComplaintResponseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetComplaintResponse()
        {
            try
            {
                var data = _repo.GetComplaintResponses();

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
        [Route("{ComplaintResponseId}/ComplaintResponseId")]
        public HttpResponseMessage GetComplaintResponse(int ComplaintResponseId)
        {
            try
            {
                var data = _repo.GetComplaintResponse(ComplaintResponseId);

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
        public HttpResponseMessage AddComplaintResponse(ComplaintResponseVM model)
        {
            try
            {
                var response = _repo.AddComplaintResponse(model);

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
        public HttpResponseMessage UpdateComplaintResponse(ComplaintResponseVM model)
        {
            try
            {
                var response = _repo.UpdateComplaintResponse(model);

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
        [Route("{ComplaintResponseId}/ComplaintResponseId")]
        public HttpResponseMessage DeleteComplaintResponse(int ComplaintResponseId)
        {
            try
            {
                var response = _repo.DeleteComplaintResponse(ComplaintResponseId);

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



     
