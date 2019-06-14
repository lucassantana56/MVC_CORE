using PAP.Business.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Repositories
{
    public interface IPublishEventRepository
    {
        void EventPublish(EventPostViewModel EventfeedPost, Guid UserId);
    }
}
