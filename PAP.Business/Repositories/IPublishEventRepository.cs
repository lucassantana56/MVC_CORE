using PAP.Business.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Repositories
{
    public interface IPublishEventRepository
    {
        void AddEventPublish(EventPostViewModel feedPost, Guid userId);
        void AddFeedBack(EventFeedIndexFeedBackViewModel FeedBack, Guid UserId);

        IEnumerable<EventFeedIndexViewModel> GetEventPublishes();
        IEnumerable<EventFeedIndexFeedBackViewModel> GetAccountPublishFeedBack(int AccountPublishId);
    }
}
