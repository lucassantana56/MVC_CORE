using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevCommunity2.Web.Controllers
{
    public class EventFeedController : Controller
    {
        // GET: EventFeed
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventFeed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventFeed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventFeed/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventFeed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventFeed/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventFeed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventFeed/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}