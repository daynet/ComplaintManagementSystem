


using SUN.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IDepartmentRepository
    {
        bool AddDepartment(DepartmentVM model);

        DepartmentVM GetDepartment(int DepartmentId);

        IEnumerable<DepartmentVM> GetDepartments();

        bool UpdateDepartment(DepartmentVM model);

        bool DeleteDepartment(int DepartmentId);
    }
}



     
