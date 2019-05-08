using Microsoft.EntityFrameworkCore;
using PAP.Business.DbContext;
using PAP.DataBase.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Account
{
   public class AccountBLL
    {

    
        public void InsertValues(User User)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=DevCommunity;Integrated Security=True");
            var context = new ApplicationDatabaseContext(optionsBuilder.Options);

            User @user = context.Users.Find(User.Id);
            
            user.Country = User.Country;
            user.PhotoUrl = User.PhotoUrl;
            context.SaveChanges();

        }
    }
}
