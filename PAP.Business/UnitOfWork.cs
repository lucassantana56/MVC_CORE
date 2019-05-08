using PAP.Business.DbContext;
using PAP.Business.Persistence.Repositories;
using PAP.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business
{
    public class UnitOfWork
    {
        private readonly ApplicationDatabaseContext _context;

        public UnitOfWork(ApplicationDatabaseContext context)
        {
            _context = context;
            Events = new EventRepository(_context);
        }

        public IEventRepository Events { get;private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
