


using cbt.Interface.CBT;
using SUN.Business.Entity;
using SUN.Business.Entity.Model;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class ComplaintResponseRepository : IComplaintResponseRepository
    {
        private DataContext _context;
        public ComplaintResponseRepository(DataContext context)
        {
            _context = context;

        }

        public bool AddComplaintResponse(ComplaintResponseVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var data = new ComplaintResponse
            {
                ComplaintResponseId = model.ComplaintResponseId,
                ComplaintId = model.ComplaintId,
                Response = model.Response,
                CreatedBy = model.CreatedBy,
                DateCreated = model.DateCreated,

            };

            _context.ComplaintResponse.Add(data);

            return _context.SaveChanges() > 0;

        }

        public IEnumerable<ComplaintResponseVM> GetComplaintResponses()
        {

            var data = (from q in _context.ComplaintResponse
                        select new ComplaintResponseVM
                        {
                            ComplaintResponseId = q.ComplaintResponseId,
                            ComplaintId = q.ComplaintId,
                            Response = q.Response,
                            CreatedBy = q.CreatedBy,
                            DateCreated = q.DateCreated,

                        }).ToList();


            return data;

        }

        public bool UpdateComplaintResponse(ComplaintResponseVM model)
        {
            var data = (from x in _context.ComplaintResponse
                        where x.ComplaintResponseId == model.ComplaintResponseId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.ComplaintResponseId = model.ComplaintResponseId;
            data.ComplaintId = model.ComplaintId;
            data.Response = model.Response;
            data.CreatedBy = model.CreatedBy;
            data.DateCreated = model.DateCreated;

            return _context.SaveChanges() > 0;

        }

        public bool DeleteComplaintResponse(int ComplaintResponseId)
        {

            if (ComplaintResponseId == 0) throw new Exception("There is nothing to delete!");

            var data = _context.ComplaintResponse.Find(ComplaintResponseId);

            if (data == null) throw new Exception("Record not found");

            _context.ComplaintResponse.Remove(data);

            return _context.SaveChanges() > 0;
        }



        public ComplaintResponseVM GetComplaintResponse(int ComplaintResponseId)
        {
            return (from x in _context.ComplaintResponse
                    where x.ComplaintResponseId == ComplaintResponseId
                    select new ComplaintResponseVM
                    {
                        ComplaintResponseId = x.ComplaintResponseId,
                        ComplaintId = x.ComplaintId,
                        Response = x.Response,
                        CreatedBy = x.CreatedBy,
                        DateCreated = x.DateCreated,


                    }).FirstOrDefault();

        }

    }
}






