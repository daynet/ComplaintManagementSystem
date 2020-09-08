


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
    public class DepartmentRepository : IDepartmentRepository
    {
        private DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;

        }

        public bool AddDepartment(DepartmentVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var data = new Department
            {
                DepartmentId = model.departmentId,
                DepartmentName = model.departmentName,

            };

            _context.Department.Add(data);

            return _context.SaveChanges() > 0;

        }

        public IEnumerable<DepartmentVM> GetDepartments()
        {

            var data = (from q in _context.Department
                        select new DepartmentVM
                        {
                            departmentId = q.DepartmentId,
                            departmentName = q.DepartmentName,

                        }).ToList();


            return data;

        }

        public bool UpdateDepartment(DepartmentVM model)
        {
            var data = (from x in _context.Department
                        where x.DepartmentId == model.departmentId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.DepartmentId = model.departmentId;
            data.DepartmentName = model.departmentName;

            return _context.SaveChanges() > 0;

        }

        public bool DeleteDepartment(int DepartmentId)
        {

            if (DepartmentId == 0) throw new Exception("There is nothing to delete!");

            var data = _context.Department.Find(DepartmentId);

            if (data == null) throw new Exception("Record not found");

            _context.Department.Remove(data);

            return _context.SaveChanges() > 0;
        }



        public DepartmentVM GetDepartment(int DepartmentId)
        {
            return (from x in _context.Department
                    where x.DepartmentId == DepartmentId
                    select new DepartmentVM
                    {
                        departmentId = x.DepartmentId,
                        departmentName = x.DepartmentName,


                    }).FirstOrDefault();

        }

    }
}






