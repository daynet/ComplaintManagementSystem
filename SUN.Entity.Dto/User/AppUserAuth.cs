using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUN.Entity.Dto.User
{
   public class AppUserAuth
    {
        public AppUserAuth() : base()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;
        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Email { get; set; }
        public string department { get; set; }
    }
}
