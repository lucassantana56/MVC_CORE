using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels.Event;
using PAP.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Persistence.Repositories
{
    public class PublishEventRepository : IPublishEventRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public PublishEventRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void EventPublish(EventPostViewModel EventfeedPost, Guid UserId)
        {
            var AccountEventPublish = new PublishEvent()
            {
                AccountId = UserId,
                DataPublish = DateTime.Now,
            };

            _context.PublishEvent.Add(AccountEventPublish);

            var contentEventPublish = new ContentPublishEvent()
            {
                PublishEventId = AccountEventPublish.PublishEventId,
                TextContent = EventfeedPost.TextOnPublish
            };

            _context.ContentPublishEvent.Add(contentEventPublish);

            var photoContentPublishAccount = new PhotoContentPublishEvent()
            {
                ContentPublishEventId = contentEventPublish.ContentPublishEventId,
                PhotoURl = EventfeedPost.Path
            };
            _context.PhotoContentPublishEvent.Add(photoContentPublishAccount);
        }

        //public IEnumerable<EventFeedIndexViewModel> GetEventPublishes()
        //{
        //    var publishEvent = (from pe in _context.PublishEvent
        //                        let ac = pe.Account
        //                        let cpe = pe.contentEventPublish
        //                        let pcpe = cpa.photoContentPublishAccount
        //                        select new FeedIndexViewModel()
        //                        {
        //                            TextOnPublish = cpe.TextContent,
        //                            UserNick = ac.NickName,
        //                            UserPublishPhoto = ac.PhotoUrl,
        //                            PhotoPath = pcpe.FirstOrDefault().PhotoURl
        //                        }).ToList();
        //    return publishEvent;
        //}
    }
}
