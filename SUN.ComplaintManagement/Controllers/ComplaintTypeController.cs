



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
    [RoutePrefix("api/v1/complainttype")]
    // [Authorize]
    public class ComplaintTypeController : ApiController
    {
        private IComplaintTypeRepository _repo;
        public ComplaintTypeController(IComplaintTypeRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetComplaintType()
        {
            try
            {
                var data = _repo.GetComplaintTypes();

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
        [Route("all/{departmentId}/departmentId")]
        public HttpResponseMessage GetallComplaintTypes(int departmentId)
        {
            try
            {
                var data = _repo.GetAllComplaintTypes(departmentId);

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
        [Route("{complaintTypeId}/ComplaintTypeId")]
        public HttpResponseMessage loadComplaintType(int complaintTypeId)
        {
            try
            {
                var data = _repo.loadComplaintType(complaintTypeId);

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
        public HttpResponseMessage GetComplaintType(int departmentId)
        {
            try
            {
                var data = _repo.GetComplaintType(departmentId);

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
        public HttpResponseMessage AddComplaintType(ComplaintTypeVM model)
        {
            try
            {
                var response = _repo.AddComplaintType(model);

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
        public HttpResponseMessage UpdateComplaintType(ComplaintTypeVM model)
        {
            try
            {
                var response = _repo.UpdateComplaintType(model);

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

        [HttpDelete]
        [Route("{ComplaintTypeId}/ComplaintTypeId")]
       // [Route("{ComplaintTypeId}")]
        public HttpResponseMessage DeleteComplaintType(int ComplaintTypeId)
        {
            try
            {
                var response = _repo.DeleteComplaintType(ComplaintTypeId);

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



     
