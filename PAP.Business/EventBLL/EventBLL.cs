using Microsoft.EntityFrameworkCore;
using PAP.Business.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.EventBLL
{
   public class EventBLL
    {
        public void CreateEvent(DateTime EventDate,string EventDescription,string EventLocationWhat3Word,string EventName,string EventPhoto,string EventType)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=DevCommunity;Integrated Security=True");
            var context = new ApplicationDatabaseContext(optionsBuilder.Options);

            DataBase.Event @event = new DataBase.Event();
            @event.DateCreated = DateTime.Now;
            @event.DateEvent = EventDate;
            @event.Description = EventDescription;
            @event.LocationWhat3words = EventLocationWhat3Word;
            @event.NameEvent = EventName;
            @event.PhotoUrl = EventPhoto;
            @event.TypeOfEvent = EventType;
            context.Add(@event);
            context.SaveChanges();
        }
        public void EventByUser(Guid UserId)
        {
            DataBase.Event @event = new DataBase.Event();
            DataBase.EventAccount @eventAccount = new DataBase.EventAccount();

            var ListEvent = (from E in @event
                             join EV in @eventAccount
                             on eventAccount.EventId equals @event.EventId
                             join AC in DataBase.Auth.User )
        }
    }
}
