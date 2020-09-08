


using SUN.Business.Entity.Model;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IComplaintRepository
    {
        Complaint AddComplaint(ComplaintVM model);

        ComplaintVM GetComplaint(int ComplaintId);

        IEnumerable<ComplaintVM> GetComplaints(string logedBy);
        IEnumerable<ComplaintVM> GetAdminComplaints();


        // ComplaintVM GetComplaintsByDepartment(int departmentId);
        IEnumerable<ComplaintVM> GetComplaintsByDepartment(int departmentId);




        bool UpdateComplaint(ComplaintVM model);


        bool UpdateStatus(ComplaintVM model);

        bool DeleteComplaint(int ComplaintId);

        string UpdateComplaintRating(ComplaintVM model);
    }
}



     
