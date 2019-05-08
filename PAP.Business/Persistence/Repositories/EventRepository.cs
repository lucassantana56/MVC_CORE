using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Persistence.Repositories
{
    public class EventRepository : Repository<EventViewModel>, IEventRepository
    {
        public EventRepository(ApplicationDatabaseContext context)
            : base(context)
        {
        }

        public void EditEvent(EventViewModel Event)
        {
            Event @event = ApplicationDatabaseContext.Event.Find(Event.EventId);

            @event.DateEvent = Event.DateEvent;
            @event.Description = Event.Description;
            @event.LocationWhat3words = Event.LocationWhat3words;
            @event.NameEvent = Event.NameEvent;
            @event.PhotoUrl = Event.PhotoUrl;
            @event.TypeOfEvent = Event.TypeOfEvent;

            ApplicationDatabaseContext.SaveChanges();
        }

        public ApplicationDatabaseContext ApplicationDatabaseContext => Context as ApplicationDatabaseContext;
    }

}
