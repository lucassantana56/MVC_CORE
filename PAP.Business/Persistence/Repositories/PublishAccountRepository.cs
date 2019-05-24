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

        public void AccountPublish(FeedPostViewModel feedPost, Guid userId)
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


            if (feedPost.PhotoBytes != null)
            {

                if (feedPost.ContentType.Contains("image"))
                {
                    string path = @"C:\Users\Admin\source\repos\PAP_Lucas\PAP.Business\Images\PublishAccountPhotos\" + feedPost.FileName;
                    FileInfo fileInfo = new FileInfo(path);

                    using (var stream = new FileStream(fileInfo.ToString(), FileMode.Create))
                    {
                        stream.Write(feedPost.PhotoBytes, 0, feedPost.PhotoBytes.Length);
                        stream.Seek(0, SeekOrigin.Begin);
                    }

                    var photoContentPublishAccount = new PhotoContentPublishAccount()
                    {
                        ContentPublishAccountId = contentPublishAccount.ContentPublishAccountId,
                        PhotoURl = path
                    };
                    _context.PhotoContentPublishAccount.Add(photoContentPublishAccount);
                }

            }
        }

        public IEnumerable<FeedIndexViewModel> GetAccountPublishes()
        {
            var accountpublish = _context.AccountPublish.Select(E => new FeedIndexViewModel()
            {
                
                TextOnPublish = E.ContentPublishAccounts.TextContent
            }).ToList();
            return accountpublish;
        }
    }
}

