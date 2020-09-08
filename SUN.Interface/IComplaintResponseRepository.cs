


using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IComplaintResponseRepository
    {
        bool AddComplaintResponse(ComplaintResponseVM model);

        ComplaintResponseVM GetComplaintResponse(int ComplaintResponseId);

        IEnumerable<ComplaintResponseVM> GetComplaintResponses();

        bool UpdateComplaintResponse(ComplaintResponseVM model);

        bool DeleteComplaintResponse(int ComplaintResponseId);
    }
}



     
