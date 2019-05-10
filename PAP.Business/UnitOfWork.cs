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

        public readonly EventRepository Events;

        public UnitOfWork(ApplicationDatabaseContext context,
            IEventRepository eventRepo)
        {
            Events = (EventRepository)eventRepo;
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
