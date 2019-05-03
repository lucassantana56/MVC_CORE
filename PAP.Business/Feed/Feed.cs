using Microsoft.EntityFrameworkCore;
using PAP.Business.DbContext;
using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Feed
{
    class Feed
    {
        
        public void Publish()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
            var context = new ApplicationDatabaseContext(optionsBuilder.Options);

            AccountPublish publish = new AccountPublish();
            publish.DatePublish = DateTime.Now;

            context.SaveChanges();
        }
    }
}
