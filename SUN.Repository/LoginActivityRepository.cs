


using Authentication.Auth;
using cbt.Interface.CBT;
using cbt.viewModel.User;
using SUN.Business.Entity.Model;
using SUN.Entity.Dto;
using SUN.Entity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class LoginActivityRepository : ILoginActivityRepository
    {
        private DataContext _context;
        private ISecurityManager securityMgr;
        public LoginActivityRepository(DataContext context, ISecurityManager _securityMgr)
        {
            _context = context;
            securityMgr = _securityMgr;

        }

        public bool AddLoginActivity(LoginActivityVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var data = new LoginActivity
            {
                LoginActivityId = model.LoginActivityId,
                UserId = model.UserId,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Email = model.Email,
                IsEmailConfirmed = model.IsEmailConfirmed,
                emailConfirmationCode = model.emailConfirmationCode,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                IsFirstLoginAttempt = model.IsFirstLoginAttempt,
                IsLockoutEnabled = model.IsLockoutEnabled,
                IsLocked = model.IsLocked,
                FailedLoginAttempt = model.FailedLoginAttempt,
                IsActive = model.IsActive,
                DeactivationDate = model.DeactivationDate,
                LastLoginDate = model.LastLoginDate,
                IsLogout = model.IsLogout,
                CreationDate = model.CreationDate,
                Department = model.Department,

            };

            _context.LoginActivity.Add(data);

            return _context.SaveChanges() > 0;

        }

        public IEnumerable<LoginActivityVM> GetLoginActivitys()
        {

            var data = (from q in _context.LoginActivity
                        select new LoginActivityVM
                        {
                            LoginActivityId = q.LoginActivityId,
                            UserId = q.UserId,
                            UserName = q.UserName,
                            FirstName = q.FirstName,
                            LastName = q.LastName,
                            Gender = q.Gender,
                            Email = q.Email,
                            IsEmailConfirmed = q.IsEmailConfirmed,
                            emailConfirmationCode = q.emailConfirmationCode,
                            PasswordHash = q.PasswordHash,
                            PasswordSalt = q.PasswordSalt,
                            IsFirstLoginAttempt = q.IsFirstLoginAttempt,
                            IsLockoutEnabled = q.IsLockoutEnabled,
                            IsLocked = q.IsLocked,
                            FailedLoginAttempt = q.FailedLoginAttempt,
                            IsActive = q.IsActive,
                            DeactivationDate = q.DeactivationDate,
                            LastLoginDate = q.LastLoginDate,
                            IsLogout = q.IsLogout,
                            CreationDate = q.CreationDate,
                            Department = q.Department,
                        }).ToList();


            return data;

        }

        public bool UpdateLoginActivity(LoginActivityVM model)
        {
            var data = (from x in _context.LoginActivity
                        where x.LoginActivityId == model.LoginActivityId
                        select x).FirstOrDefault();

            if (data == null) throw new Exception("Record not found");

            data.LoginActivityId = model.LoginActivityId;
            data.UserId = model.UserId;
            data.UserName = model.UserName;
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Gender = model.Gender;
            data.Email = model.Email;
            data.IsEmailConfirmed = model.IsEmailConfirmed;
            data.emailConfirmationCode = model.emailConfirmationCode;
            data.PasswordHash = model.PasswordHash;
            data.PasswordSalt = model.PasswordSalt;
            data.IsFirstLoginAttempt = model.IsFirstLoginAttempt;
            data.IsLockoutEnabled = model.IsLockoutEnabled;
            data.IsLocked = model.IsLocked;
            data.FailedLoginAttempt = model.FailedLoginAttempt;
            data.IsActive = model.IsActive;
            data.DeactivationDate = model.DeactivationDate;
            data.LastLoginDate = model.LastLoginDate;
            data.IsLogout = model.IsLogout;
            data.CreationDate = model.CreationDate;

            return _context.SaveChanges() > 0;

        }

        public bool DeleteLoginActivity(int LoginActivityId)
        {

            if (LoginActivityId == 0) throw new Exception("There is nothing to delete!");

            var data = _context.LoginActivity.Find(LoginActivityId);

            if (data == null) throw new Exception("Record not found");

            _context.LoginActivity.Remove(data);

            return _context.SaveChanges() > 0;
        }



        public LoginActivityVM GetLoginActivity(int LoginActivityId)
        {
            return (from x in _context.LoginActivity
                    where x.LoginActivityId == LoginActivityId
                    select new LoginActivityVM
                    {
                        LoginActivityId = x.LoginActivityId,
                        UserId = x.UserId,
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Gender = x.Gender,
                        Email = x.Email,
                        IsEmailConfirmed = x.IsEmailConfirmed,
                        emailConfirmationCode = x.emailConfirmationCode,
                        PasswordHash = x.PasswordHash,
                        PasswordSalt = x.PasswordSalt,
                        IsFirstLoginAttempt = x.IsFirstLoginAttempt,
                        IsLockoutEnabled = x.IsLockoutEnabled,
                        IsLocked = x.IsLocked,
                        FailedLoginAttempt = x.FailedLoginAttempt,
                        IsActive = x.IsActive,
                        DeactivationDate = x.DeactivationDate,
                        LastLoginDate = x.LastLoginDate,
                        IsLogout = x.IsLogout,
                        CreationDate = x.CreationDate,


                    }).FirstOrDefault();

        }

        public async Task<AppUserAuth> Login(UserLoginVM user)
        {
            AppUserAuth auth = new AppUserAuth();

            return securityMgr.ValidateUser(user);

        }

    }
}






