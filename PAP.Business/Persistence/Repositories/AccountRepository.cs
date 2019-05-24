using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
using PAP.DataBase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAP.Business.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public AccountRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void UpdateData(User user)
        {
            if (user.PhotoUrl == null)
            {
                user.PhotoUrl = "~Images/UserPhotos/DefaultUserPhoto.png";
            }

            var User = _context.Users
                .Where(e => e.Id == user.Id)
                .Select(e => new AccountViewModel()
                {
                    Country = user.Country,
                    PhotoUrl = user.PhotoUrl,
                    ProgramminglLanguages = user.ProgrammingLanguages,
                }).FirstOrDefault();
        }

        public AccountViewModel GetUserInfo(Guid userId)
        {



            var User = _context.Users
                .Where(e => e.Id == userId)
                .Select(e => new AccountViewModel()
                {
                    UserName = e.UserName,
                    PhotoUrl = e.PhotoUrl,
                }).FirstOrDefault();

            return User;

        }

    }
}
