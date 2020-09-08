


using cbt.viewModel.User;
using SUN.Entity.Dto;
using SUN.Entity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface ILoginActivityRepository
    {
        bool AddLoginActivity(LoginActivityVM model);

        LoginActivityVM GetLoginActivity(int LoginActivityId);

        IEnumerable<LoginActivityVM> GetLoginActivitys();

        bool UpdateLoginActivity(LoginActivityVM model);

        bool DeleteLoginActivity(int LoginActivityId);
        Task<AppUserAuth> Login(UserLoginVM user);
    }
}



     
