using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAP.Business.Managers;
using PAP.Business.Persistence.Repositories;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
using PAP.Business.ViewModels.Event;

namespace DevCommunity2.Web.Controllers
{
    public class EventFeedController : Controller
    {
        private readonly PublishEventRepository _publishEventRepository;
        private readonly BaseManager _BaseManager;
        private readonly HostingEnvironment _hostingEnvironment;


        public EventFeedController(IPublishEventRepository publishEventRepository, BaseManager baseManager, IHostingEnvironment hostingEnvironment)
        {
            _publishEventRepository = (PublishEventRepository)publishEventRepository;
            _BaseManager = baseManager;
            _hostingEnvironment = (HostingEnvironment)hostingEnvironment;
        }

        public ActionResult Index()
        {

            var result = _publishEventRepository.GetEventPublishes().ToList();
            return View(result);
        }

        // GET: Feed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feed/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventPostViewModel FeedPost, IFormFile File)
        {
            try
            {

                var uploadFolder = Path.Combine(
                    _hostingEnvironment.WebRootPath, "Images", "AccountPublish");
                var uniqueFileName = Guid.NewGuid() + File.FileName;

                var path = Path.Combine(uploadFolder, uniqueFileName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }


                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

                string pic = System.IO.Path.GetFileName(File.FileName);

                FeedPost.Path = uniqueFileName;

                _publishEventRepository.AddEventPublish(FeedPost, userId);
                _BaseManager.SaveChanges();

                return Json(new { success = true, message = "sucess" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "erro" });
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFeedBack(EventFeedIndexViewModel feedIndexViewModel)
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

            if (userId == null)
            {
                return Json(new { success = false, message = "erro" });
            }

            var fifvm = new EventFeedIndexFeedBackViewModel()
            {
               EventPublishId  = feedIndexViewModel.AccountPublishId,
               EventFeedBackText  = feedIndexViewModel.FeedBackText
            };

            try
            {

                _publishEventRepository.AddFeedBack(fifvm, userId);
                _BaseManager.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        // GET: Feed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Feed/Edit/5
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

        // GET: Feed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Feed/Delete/5
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