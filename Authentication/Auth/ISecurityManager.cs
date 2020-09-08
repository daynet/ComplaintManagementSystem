//using cbt.viewModel.User;
//using cbt.viewModel.User;
using cbt.viewModel.User;
using SUN.Entity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Auth
{
  public interface ISecurityManager
    {
        AppUserAuth ValidateUser(UserLoginVM user);
    }
}
