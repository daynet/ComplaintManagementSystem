


using cbt.Common;
using cbt.Interface.CBT;
using SUN.Business.Entity;
using SUN.Business.Entity.Model;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cbt.repository.CBT
{
    public class ComplaintRepository : IComplaintRepository
    {
        private DataContext _context;
        public ComplaintRepository(DataContext context)
        {
            _context = context;

        }

        public Complaint AddComplaint(ComplaintVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");


            var data = new Complaint
            {
                ComplaintId = model.complaintId,
                LogedBy = model.logedBy,
                Title = model.title,
                ComplaintTypeId = model.complaintTypeId,
                DepartmentId = model.departmentId,
                ComplaintDetail = model.complaintDetail,
                DateCreated = DateTime.Now,
                StatusId = 1,
                RatingId = 0,
                PriorityId = model.priorityId,


            };

          var complain =   _context.Complaint.Add(data);

           if( _context.SaveChanges() > 0)
            {
                // string url = HttpContext.Current.Request.Url.AbsoluteUri;
                String path = String.Format(ConfigurationManager.AppSettings["path"]);
                var email = _context.Department.Where(x => x.DepartmentId == complain.DepartmentId).Select(x => x.Email).FirstOrDefault();
                var departmentName = _context.Department.Where(x => x.DepartmentId == complain.DepartmentId).Select(x => x.DepartmentName).FirstOrDefault();
               // var absoluteToRelative = new Uri("http://localhost:4200/#/complaintresponse" + "?departmentId=" + complain.DepartmentId);
                var absoluteToRelative = new Uri(path + "?departmentId=" + complain.DepartmentId);
                string messageContent = $"Hello, <br /><br />" +
                                        "There is a request that awaits your team. <br />" +
                                        "Kindly click on this link   " + "<a href ="+ absoluteToRelative + "> View Complaint </a>" + " to attend to the request";

                SendEmailAPI.SendEmail("", email, "Skyline University NIgeria Student Complaint ", messageContent, "");

                string messageContentSSD = $"Hello, <br /><br />" +
                                        "A request has been initiated by a student. <br />" +
                                        "Kindly find details below. <br/><br/>   " + "<b>Username:</b>" + complain.LogedBy + "<br/><br/> <b>Concerned Department:</b>" + departmentName + "<br/><br/><b>Student Complaint Detail:</b>"
                                        + complain.ComplaintDetail;



                 SendEmailAPI.SendEmail("", "ssd.executive@sun.edu.ng", "Skyline University Nigeria Student Complaint ", messageContentSSD, ""); //ssd.executive@sun.edu.ng
              //  SendEmailAPI.SendEmail("", "dos024@yahoo.com", "Skyline University Nigeria Student Complaint ", messageContentSSD, ""); //ssd.executive@sun.edu.ng

            }



            return complain;
        }

        public IEnumerable<ComplaintVM> GetComplaints(string logedBy)
        {

            var data = (from q in _context.Complaint
                        where q.LogedBy == logedBy
                        select new ComplaintVM
                        {
                            complaintId = q.ComplaintId,
                            logedBy = q.LogedBy,
                            complaintTypeId = q.ComplaintTypeId,
                            departmentId = q.DepartmentId,
                            title = q.Title,
                            complaintDetail = q.ComplaintDetail,
                            dateCreated = q.DateCreated,
                            status = _context.Status.Where(x=>x.StatusId== q.StatusId).Select(x=>x.StatusName).FirstOrDefault(),
                            priority = _context.Priority.Where(x=>x.PriorityId == q.PriorityId).Select(x=>x.PriorityName).FirstOrDefault(),
                            rating = _context.Rating.Where(x=>x.RatingId==q.RatingId).Select(x=>x.Rating1).FirstOrDefault(),
                            departmentName = _context.Department.Where(o=>o.DepartmentId==q.DepartmentId).Select(o=>o.DepartmentName).FirstOrDefault(),
                            complaintType = _context.ComplaintType.Where(o=>o.ComplaintTypeId==q.ComplaintTypeId).Select(o=>o.ComplaintName).FirstOrDefault(),
                            ComplaintResponse = q.ComplaintResponse,
                        }).ToList();


            return data;

        }

        public IEnumerable<ComplaintVM> GetAdminComplaints()
        {

            var data = (from q in _context.Complaint
                        //where q.LogedBy == logedBy
                        select new ComplaintVM
                        {
                            complaintId = q.ComplaintId,
                            logedBy = q.LogedBy,
                            complaintTypeId = q.ComplaintTypeId,
                            departmentId = q.DepartmentId,
                            title = q.Title,
                            complaintDetail = q.ComplaintDetail,
                            dateCreated = q.DateCreated,
                            status = _context.Status.Where(x => x.StatusId == q.StatusId).Select(x => x.StatusName).FirstOrDefault(),
                            priority = _context.Priority.Where(x => x.PriorityId == q.PriorityId).Select(x => x.PriorityName).FirstOrDefault(),
                            rating = _context.Rating.Where(x => x.RatingId == q.RatingId).Select(x => x.Rating1).FirstOrDefault(),
                            departmentName = _context.Department.Where(o => o.DepartmentId == q.DepartmentId).Select(o => o.DepartmentName).FirstOrDefault(),
                            complaintType = _context.ComplaintType.Where(o => o.ComplaintTypeId == q.ComplaintTypeId).Select(o => o.ComplaintName).FirstOrDefault(),
                            ComplaintResponse = q.ComplaintResponse,
                        }).ToList();


            return data;

        }


        //  public ComplaintVM GetComplaintsByDepartment(int departmentId)
        public IEnumerable<ComplaintVM> GetComplaintsByDepartment(int departmentId)
        {
            var data = (from q in _context.Complaint
                        where q.DepartmentId == departmentId

                        orderby q.ComplaintId descending
                            // where q.LogedBy == logedBy
                        select new ComplaintVM
                        {
                            complaintId = q.ComplaintId,
                            logedBy = q.LogedBy,
                            complaintTypeId = q.ComplaintTypeId,
                            departmentId = q.DepartmentId,
                            title = q.Title,
                            complaintDetail = q.ComplaintDetail,
                            dateCreated = q.DateCreated,
                            status = _context.Status.Where(x => x.StatusId == q.StatusId).Select(x => x.StatusName).FirstOrDefault(),
                            priority = _context.Priority.Where(x => x.PriorityId == q.PriorityId).Select(x => x.PriorityName).FirstOrDefault(),
                            rating = _context.Rating.Where(x => x.RatingId == q.RatingId).Select(x => x.Rating1).FirstOrDefault(),
                            departmentName = _context.Department.Where(o => o.DepartmentId == q.DepartmentId).Select(o => o.DepartmentName).FirstOrDefault(),
                            complaintType = _context.ComplaintType.Where(o => o.ComplaintTypeId == q.ComplaintTypeId).Select(o => o.ComplaintName).FirstOrDefault(),

                        }).ToList();

            return data;

        }

        public bool UpdateComplaint(ComplaintVM model)
        {
            var data = (from x in _context.Complaint
                        where x.ComplaintId == model.complaintId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.ComplaintId = model.complaintId;
            data.LogedBy = model.logedBy;
            data.ComplaintTypeId = model.complaintTypeId;
            data.DepartmentId = model.departmentId;
            data.ComplaintDetail = model.complaintDetail;
            data.DateCreated = model.dateCreated;
            data.StatusId = model.statusId;
            data.PriorityId = model.priorityId;
            data.Title = model.title;

            return _context.SaveChanges() > 0;

        }


        public bool UpdateStatus(ComplaintVM model)
        {
            var data = (from x in _context.Complaint
                        where x.ComplaintId == model.complaintId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.ComplaintId = model.complaintId;
            //data.LogedBy = model.logedBy;
            //data.ComplaintTypeId = model.complaintTypeId;
            //data.DepartmentId = model.departmentId;
            //data.ComplaintDetail = model.complaintDetail;
            //data.DateCreated = model.dateCreated;
            data.StatusId = model.statusId;
            //data.PriorityId = model.priorityId;
            //data.Title = model.title;
            data.ComplaintResponse = model.ComplaintResponse;

            return _context.SaveChanges() > 0;

        }

        public string UpdateComplaintRating(ComplaintVM model)
        {
            var data = (from x in _context.Complaint
                        where x.ComplaintId == model.complaintId
                        select x).FirstOrDefault();

            if (data == null) return "Complaint not found!";

            if(data.StatusId==1) return "This complaint has not been attended";

            data.RatingId = model.ratingId;

            if (_context.SaveChanges() > 0)
                return "Rated Successfully!";

            return "Rating not successfully updated. Try again!!!!";
        }

        public bool DeleteComplaint(int ComplaintId)
        {

            if (ComplaintId == 0) throw new Exception("There is nothing to delete!");

            var data = _context.Complaint.Find(ComplaintId);

            if (data == null) throw new Exception("Record not found");

            _context.Complaint.Remove(data);

            return _context.SaveChanges() > 0;
        }



        public ComplaintVM GetComplaint(int ComplaintId)
        {
            return (from x in _context.Complaint
                    where x.ComplaintId == ComplaintId
                    select new ComplaintVM
                    {
                        complaintId = x.ComplaintId,
                        logedBy = x.LogedBy,
                        complaintTypeId = x.ComplaintTypeId,
                        departmentId = x.DepartmentId,
                        title = x.Title,
                        complaintDetail = x.ComplaintDetail,
                        dateCreated = x.DateCreated,
                        statusId = x.StatusId,
                        priorityId = x.PriorityId,


                    }).FirstOrDefault();

        }


       

      
    }


}






