


using cbt.Interface.CBT;
using SUN.Business.Entity.Model;
using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class ComplaintTypeRepository : IComplaintTypeRepository
    {
        private DataContext _context;
        public ComplaintTypeRepository(DataContext context)
        {
            _context = context;

        }

        public bool AddComplaintType(ComplaintTypeVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var data = new ComplaintType
            {
                ComplaintTypeId = model.complaintTypeId,
                DepartmentId = model.departmentId,
                ComplaintName = model.complaintName,

            };

            _context.ComplaintType.Add(data);

            return _context.SaveChanges() > 0;

        }

        public IEnumerable<ComplaintTypeVM> GetComplaintTypes()
        {

            var data = (from q in _context.ComplaintType
                        join d in _context.Department
                        on q.DepartmentId equals d.DepartmentId
                        select new ComplaintTypeVM
                        {
                            complaintTypeId = q.ComplaintTypeId,
                            departmentId = q.DepartmentId,
                            complaintName = q.ComplaintName,
                            departmentName = d.DepartmentName



                        }).ToList();


            return data;

        }

        public IEnumerable<ComplaintTypeVM> GetAllComplaintTypes(int departmentId)
        {

            var data = (from q in _context.ComplaintType
                        join d in _context.Department
                        on q.DepartmentId equals d.DepartmentId

                        where q.DepartmentId == departmentId
                        select new ComplaintTypeVM
                        {
                            complaintTypeId = q.ComplaintTypeId,
                            departmentId = q.DepartmentId,
                            complaintName = q.ComplaintName,
                            departmentName = d.DepartmentName



                        }).ToList();


            return data;

        }

        public bool UpdateComplaintType(ComplaintTypeVM model)
        {
            var data = (from x in _context.ComplaintType
                        where x.ComplaintTypeId == model.complaintTypeId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.ComplaintTypeId = model.complaintTypeId;
            data.DepartmentId = model.departmentId;
            data.ComplaintName = model.complaintName;

            return _context.SaveChanges() > 0;

        }

        public bool DeleteComplaintType(int ComplaintTypeId)
        {

            if (ComplaintTypeId == 0) throw new Exception("There is nothing to delete!");

            var data = _context.ComplaintType.Find(ComplaintTypeId);

            if (data == null) throw new Exception("Record not found");

            _context.ComplaintType.Remove(data);

            return _context.SaveChanges() > 0;
        }



        public ComplaintTypeVM GetComplaintType(int departmentId)
        {
            return (from x in _context.ComplaintType
                    where x.DepartmentId == departmentId
                    select new ComplaintTypeVM
                    {
                        complaintTypeId = x.ComplaintTypeId,
                        departmentId = x.DepartmentId,
                        complaintName = x.ComplaintName,


                    }).FirstOrDefault();

        }

        public ComplaintTypeVM loadComplaintType(int complaintId)
        {
            return (from x in _context.ComplaintType
                    join d in _context.Department
                    on   x.DepartmentId equals d.DepartmentId
                    where x.ComplaintTypeId == complaintId
                    select new ComplaintTypeVM
                    {
                        complaintTypeId = x.ComplaintTypeId,
                        //departmentId = x.DepartmentId,
                        complaintName = x.ComplaintName,
                        departmentName = d.DepartmentName


                    }).FirstOrDefault();

        }

    }
}






