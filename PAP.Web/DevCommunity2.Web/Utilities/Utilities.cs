using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAP.Business.Managers;
using PAP.Business.Persistence.Repositories;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;

namespace DevCommunity2.Web.Utilities
{
    public class Utilities
    {
        private readonly EventRepository _eventRepo;
        private readonly BaseManager _BaseManager;

        public Utilities(IEventRepository eventRepo, BaseManager baseManager)
        {
            _eventRepo = (EventRepository)eventRepo;
            _BaseManager = (BaseManager)baseManager;
        } 
    }
}
