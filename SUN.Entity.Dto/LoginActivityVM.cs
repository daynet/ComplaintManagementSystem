using System;

namespace SUN.Entity.Dto
{

    public class LoginActivityVM
    {
        public int LoginActivityId { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public bool? IsEmailConfirmed { get; set; }

        public string emailConfirmationCode { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool? IsFirstLoginAttempt { get; set; }

        public bool? IsLockoutEnabled { get; set; }

        public bool? IsLocked { get; set; }

        public int? FailedLoginAttempt { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DeactivationDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? IsLogout { get; set; }

        public DateTime? CreationDate { get; set; }

        public string Department { get; set; }
    }
}      
