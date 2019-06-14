using PAP.Business.DbContext;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
using System;
using System.Collections.Generic;
using PAP.DataBase;
using System.Linq;
using System.IO;

namespace PAP.Business.Persistence.Repositories
{
    public class PublishAccountRepository : IPublishAccountRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public PublishAccountRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void AddAccountPublish(FeedPostViewModel feedPost, Guid userId)
        {
            var AccountPublish = new AccountPublish()
            {
                AccountId = userId,
                DatePublish = DateTime.Now,
            };

            _context.AccountPublish.Add(AccountPublish);

            var contentPublishAccount = new ContentPublishAccount()
            {
                AccountPublishId = AccountPublish.AccountPublishId,
                TextContent = feedPost.TextOnPublish
            };

            _context.ContentPublishAccount.Add(contentPublishAccount);

            var photoContentPublishAccount = new PhotoContentPublishAccount()
            {
                ContentPublishAccountId = contentPublishAccount.ContentPublishAccountId,
                PhotoURl = feedPost.Path
            };
            _context.PhotoContentPublishAccount.Add(photoContentPublishAccount);
        }

        public IEnumerable<FeedIndexViewModel> GetAccountPublishes()
        {
            var accountpublish = (from ap in _context.AccountPublish
                                  let ac = ap.Account
                                  let cpa = ap.ContentPublishAccounts
                                  let pcpa = cpa.PhotoContentPublishAccounts
                                  select new FeedIndexViewModel()
                                  {
                                      ContentPublishId = cpa.ContentPublishAccountId,
                                      AccountPunlishId = ap.AccountPublishId,
                                      TextOnPublish = cpa.TextContent,
                                      UserNick = ac.NickName,
                                      UserPublishPhoto = ac.PhotoUrl,
                                      PhotoPath = pcpa.FirstOrDefault().PhotoURl
                                  }).ToList();
            return accountpublish;
        }

        public IEnumerable<FeedIndexFeedBackViewModel> GetAccountPublishFeedBack(int AccountPublishId)
        {           
            var FeedAccountPublishFeedBack = from AP in _context.AccountPublish
                                             join CP in _context.ContentPublishAccount
                                             on AP.AccountPublishId equals CP.AccountPublishId
                                             join FBCA in _context.FeedBackContentAccount
                                             on AP.AccountPublishId equals FBCA.AccountPublishId
                                             where AP.AccountPublishId == AccountPublishId
                                             select new FeedIndexFeedBackViewModel()
                                             {                                               
                                                 FeedBackText = FBCA.Description
                                             };

            return FeedAccountPublishFeedBack;

        }


        public void AddFeedBack(FeedIndexFeedBackViewModel FeedBack, Guid UserId )
        {
            var accountPublishFeedBack = new FeedBackContentAccount()
            {
                AccountId = UserId,
                AccountPublishId = FeedBack.AccountPublishId,
                Description = FeedBack.FeedBackText
            };
            _context.FeedBackContentAccount.AddAsync(accountPublishFeedBack);
        }
    }
}

