


using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IComplaintTypeRepository
    {
        bool AddComplaintType(ComplaintTypeVM model);

        ComplaintTypeVM GetComplaintType(int ComplaintTypeId);
        IEnumerable<ComplaintTypeVM> GetComplaintTypes();


        IEnumerable<ComplaintTypeVM> GetAllComplaintTypes(int ComplaintTypeId);

        bool UpdateComplaintType(ComplaintTypeVM model);

        bool DeleteComplaintType(int ComplaintTypeId);

        ComplaintTypeVM loadComplaintType(int ComplaintTypeId);


    }
}



     
