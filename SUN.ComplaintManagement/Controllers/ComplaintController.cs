



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
    [RoutePrefix("api/v1/complaint")]
    // [Authorize]
    public class ComplaintController : ApiController
    {
        private IComplaintRepository _repo;
        public ComplaintController(IComplaintRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("{logedBy}/logedBy")]
        public HttpResponseMessage GetComplaints(string logedBy)
        {
            try
            {
                var data = _repo.GetComplaints(logedBy);

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
        [Route("")]
        public HttpResponseMessage GetAdminComplaints()
        {
            try
            {
                var data = _repo.GetAdminComplaints();

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
        [Route("{ComplaintId}/ComplaintId")]
        public HttpResponseMessage GetComplaint(int ComplaintId)
        {
            try
            {
                var data = _repo.GetComplaint(ComplaintId);

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



        [HttpGet]
        [Route("{departmentId}/departmentId")]
        public HttpResponseMessage GetComplaintbyDepartment(int departmentId)
        {
            try
            {
                var data = _repo.GetComplaintsByDepartment(departmentId);

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
        public HttpResponseMessage AddComplaint(ComplaintVM model)
        {
            try
            {
                var response = _repo.AddComplaint(model);

                if (response == null)
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
        public HttpResponseMessage UpdateComplaint(ComplaintVM model)
        {
            try
            {
                var response = _repo.UpdateComplaint(model);

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
        [Route("rating")]
        public HttpResponseMessage UpdateComplaintRating(ComplaintVM model)
        {
            try
            {
                var response = _repo.UpdateComplaintRating(model);

                if (response == "")
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
        [Route("{ComplaintId}/ComplaintId")]
        public HttpResponseMessage DeleteComplaint(int ComplaintId)
        {
            try
            {
                var response = _repo.DeleteComplaint(ComplaintId);

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
        [Route("status")]
        public HttpResponseMessage UpdateStatus(ComplaintVM model)
        {
            try
            {
                var response = _repo.UpdateStatus(model);

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



     
