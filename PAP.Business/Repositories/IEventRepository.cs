using PAP.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Repositories
{
    public interface IEventRepository : IRepository<EventViewModel>
    {
        void EditEvent(EventViewModel Event);
       
    }
}
