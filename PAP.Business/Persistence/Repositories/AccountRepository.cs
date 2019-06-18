using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
using PAP.Business.ViewModels.Account;
using PAP.DataBase.Auth;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void UpdateData(AccountDataViewModel user, Guid UserId)
        {
            var User = _context.Users.Find(UserId);
            User.PhotoUrl = user.PhotoUniqueName;
            User.Country = user.Country;
            User.ProgrammingLanguages = user.ProgramminglLanguages;

        }

        public AccountInfoViewModel GetUserInfo(Guid userId)
        {
            var User = _context.Users
                .Where(e => e.Id == userId)
                .Select(e => new AccountInfoViewModel()
                {
                    Nickname = e.NickName,
                    PhotoUrl = e.PhotoUrl
                }).FirstOrDefault();

            return User;

        }

    }
}
