using PAP.Business.DbContext;
using PAP.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Persistence.Repositories
{
    public class FeedRepository : IFeedRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public FeedRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }
    }
}
