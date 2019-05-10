using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAP.Business;
using PAP.Business.Managers;
using PAP.Business.Persistence.Repositories;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;

namespace DevCommunity2.Web.Controllers
{

    public class EventController : Controller
    {

        private readonly EventRepository _eventRepo;
        private readonly BaseManager _BaseManager;

        public EventController(IEventRepository eventRepo,BaseManager baseManager)
        {
            _eventRepo = (EventRepository)eventRepo;
            _BaseManager = (BaseManager)baseManager;
        }


        // GET: Event
        public ActionResult Index()
        {
            return View(_eventRepo.GetAll());
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(_eventRepo.Get(id));
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }

        // GET: Event/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult tst()
        {
            return View();
        }
        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel @event)
        {
            try
            {
                //  string userid = User.
                //Guid.TryParse(userid, out Guid usertst);
                // TODO: Add insert logic here           
                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier),out Guid userId);
                _eventRepo.Add(@event, userId);
                _BaseManager.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("EventId,NameEvent,DateCreated,DateEvent,TypeOfEvent,LocationWhat3words,PhotoUrl,Description,Stars")] EventViewModel @event)
        {
            // TODO: Add update logic here
            try
            {
                _eventRepo.EditEvent(@event);
                return View();
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EventViewModel @event)
        {
            try
            {
                // TODO: Add delete logic here
                //_eventRepo.Remove(@event);
                //_eventRepo.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}