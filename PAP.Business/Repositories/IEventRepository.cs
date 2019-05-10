using PAP.Business.ViewModels;
using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Repositories
{
    public interface IEventRepository
    {
        EventViewModel Get(int id);
        IEnumerable<EventViewModel> GetAll();
        void Add(EventViewModel @event,Guid UserId);
        void Remove(EventViewModel @event);
        void EditEvent(EventViewModel @event);
    }
}
