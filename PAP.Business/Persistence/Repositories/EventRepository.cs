using Microsoft.EntityFrameworkCore.Internal;
using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAP.Business.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly ApplicationDatabaseContext _context;

        public EventRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public EventViewModel Get(int id)
        {
            var @event = _context.Event.Select(e => new EventViewModel()
            {
                EventId = e.EventId,
                EventName= e.NameEvent,
                EventDate = e.DateEvent,
                TypeOfEvent = e.TypeOfEvent,
                Location = e.Location
            }).FirstOrDefault(e => e.EventId == id);

            return @event;
        }

        public  IEnumerable<EventViewModel> GetAll()
        {
            var @event = _context.Event.Select(e => new EventViewModel()
            {
                EventId = e.EventId,
                EventName = e.NameEvent,
                EventDate = e.DateEvent,
                TypeOfEvent = e.TypeOfEvent,
                Location = e.Location
            }).ToList();
            return @event.ToList();
        }

        //public EventViewModel GetEventByUser()
        //{
        //    var @event = _context.Event.Select(e => new EventViewModel()
        //    {
        //        accs = e.EventAccounts.Select
        //    })


        //}

        public void Add(EventViewModel entity)
        {
            var @event = new Event();
            @event.DateCreated = DateTime.Now.Date;
            @event.DateEvent = entity.EventDate;
            @event.Description = entity.Description;
            @event.Location = entity.Location;
            @event.NameEvent = entity.EventName;
            if (entity.PhotoUrl==null)
            {
             @event.PhotoUrl = "~/Images/EventPhotos/DefaulEventPhoto.png";
            }
            else
            {
                @event.PhotoUrl = entity.PhotoUrl;
            }
            @event.TypeOfEvent = entity.TypeOfEvent;
                       
            _context.Event.Add(@event);
        }

        public void Remove(EventViewModel entity)
        {
            var @event = new Event();
            @event.EventId = entity.EventId;

            _context.Event.Remove(@event);
        }

        public void EditEvent(EventViewModel entity)
        {
            var @event = _context.Event.Select(e => new EventViewModel()
            {
                EventId = e.EventId,
                EventName = e.NameEvent,
                EventDate = e.DateEvent,
                TypeOfEvent = e.TypeOfEvent,
                Location = e.Location,
                PhotoUrl = e.PhotoUrl
                
            }).FirstOrDefault( e=> e.EventId == entity.EventId);         
        } 
    }

}
