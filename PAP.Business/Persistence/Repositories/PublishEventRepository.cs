using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels.Event;
using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PAP.Business.Persistence.Repositories
{
    public class PublishEventRepository : IPublishEventRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public PublishEventRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void AddEventPublish(EventPostViewModel feedPost, Guid userId)
        {
            var publishEvent = new PublishEvent()
            {
                AccountId = userId,
                PublishDate = DateTime.Now,
            };

            _context.PublishEvent.Add(publishEvent);

            var contentPublishEvent = new ContentPublishEvent()
            {
                PublishEventId = publishEvent.PublishEventId,
                TextContent = feedPost.TextOnPublish
            };

            _context.ContentPublishEvent.Add(contentPublishEvent);

            var photoContentPublishEvent = new PhotoContentPublishEvent()
            {
                ContentPublishEventId = contentPublishEvent.ContentPublishEventId,
                PhotoURl = feedPost.Path
            };
            _context.PhotoContentPublishEvent.Add(photoContentPublishEvent);
        }

        public IEnumerable<EventFeedIndexViewModel> GetEventPublishes()
        {
            var EventPublish = from pe in _context.PublishEvent
                               join ac in _context.Users
                               on pe.AccountId equals ac.Id
                               join ce in _context.ContentPublishEvent
                               on pe.PublishEventId equals ce.PublishEventId
                               join pce in _context.PhotoContentPublishEvent
                               on ce.ContentPublishEventId equals pce.ContentPublishEventId
                               select new EventFeedIndexViewModel
                               {
                                   ContentPublishId = ce.ContentPublishEventId,
                                   AccountPublishId = pe.PublishEventId,
                                   TextOnPublish = ce.TextContent,
                                   UserNick = ac.NickName,
                                   UserPublishPhoto = ac.PhotoUrl,
                                   PhotoPath = pce.PhotoURl,
                                   EventFeedIndexFeedBacks = GetAccountPublishFeedBack(pe.PublishEventId)
                               };

            return EventPublish;
        }

        public IEnumerable<EventFeedIndexFeedBackViewModel> GetAccountPublishFeedBack(int PublishEventId)
        {
            var FeedEventPublishFeedBack = from AP in _context.AccountPublish
                                           join AC in _context.Users on
                                           AP.AccountId equals AC.Id
                                           join FBCA in _context.FeedBackContentAccount
                                           on AP.AccountId equals FBCA.AccountId
                                           select new EventFeedIndexFeedBackViewModel()
                                           {
                                               EventFeedBackText = FBCA.Description,
                                               UserNick = AC.NickName,
                                               UserPhoto = AC.PhotoUrl
                                           };

            return FeedEventPublishFeedBack;

        }


        public void AddFeedBack(EventFeedIndexFeedBackViewModel FeedBack, Guid UserId)
        {
            var accountPublishFeedBack = new FeedBackContentAccount()
            {
                AccountId = UserId,
                AccountPublishId = FeedBack.EventPublishId,
                Description = FeedBack.EventFeedBackText
            };

            _context.FeedBackContentAccount.AddAsync(accountPublishFeedBack);
        }
    }
}
