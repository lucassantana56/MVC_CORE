using Microsoft.AspNetCore.Http;
using PAP.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAP.Business.Repositories
{
    public interface IPublishAccountRepository
    {
        void AccountPublish(FeedPostViewModel accountPublish,Guid userId);

        IEnumerable<FeedIndexViewModel> GetAccountPublishes();
    }
}
