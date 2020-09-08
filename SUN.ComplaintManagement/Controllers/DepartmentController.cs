



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
    [RoutePrefix("api/v1/department")]
    // [Authorize]
    public class DepartmentController : ApiController
    {
        private IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetDepartment()
        {
            try
            {
                var data = _repo.GetDepartments();

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
        [Route("{DepartmentId}/DepartmentId")]
        public HttpResponseMessage GetDepartment(int DepartmentId)
        {
            try
            {
                var data = _repo.GetDepartment(DepartmentId);

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
        public HttpResponseMessage AddDepartment(DepartmentVM model)
        {
            try
            {
                var response = _repo.AddDepartment(model);

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
        public HttpResponseMessage UpdateDepartment(DepartmentVM model)
        {
            try
            {
                var response = _repo.UpdateDepartment(model);

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
        [Route("{DepartmentId}/DepartmentId")]
        public HttpResponseMessage DeleteDepartment(int DepartmentId)
        {
            try
            {
                var response = _repo.DeleteDepartment(DepartmentId);

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



     
