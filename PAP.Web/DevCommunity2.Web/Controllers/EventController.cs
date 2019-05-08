using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAP.Business;
using PAP.Business.DbContext;
using PAP.Business.ViewModels;

namespace DevCommunity2.Web.Controllers
{
   
    public class EventController : Controller
    {
      

        // GET: Event
        public ActionResult Index()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
            var unitOfWork = new UnitOfWork(new ApplicationDatabaseContext(optionsBuilder.Options));
            return View(unitOfWork.Events.GetAll());
        }

        // GET: Event/Details/5
        public ActionResult Details()
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
                var unitOfWork = new UnitOfWork(new ApplicationDatabaseContext(optionsBuilder.Options));
                return View(unitOfWork.Events.Get(1));
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

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("EventId,NameEvent,DateCreated,DateEvent,TypeOfEvent,LocationWhat3words,PhotoUrl,Description,Stars")] EventViewModel @event)
        {
            try
            {
                // TODO: Add insert logic here
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
                var unitOfWork = new UnitOfWork(new ApplicationDatabaseContext(optionsBuilder.Options));
                unitOfWork.Events.Add(@event);
                unitOfWork.Complete();
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
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
                var unitOfWork = new UnitOfWork(new ApplicationDatabaseContext(optionsBuilder.Options));
                return View(unitOfWork.Events.Get(id));
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
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
                var unitOfWork = new UnitOfWork(new ApplicationDatabaseContext(optionsBuilder.Options));
                unitOfWork.Events.EditEvent(@event);
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
        public ActionResult Delete([Bind("EventId,NameEvent,DateCreated,DateEvent,TypeOfEvent,LocationWhat3words,PhotoUrl,Description,Stars")] EventViewModel @event)
        {
            try
            {
                // TODO: Add delete logic here
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabaseContext>();
                var unitOfWork = new UnitOfWork(new ApplicationDatabaseContext(optionsBuilder.Options));
                unitOfWork.Events.Remove(@event);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}