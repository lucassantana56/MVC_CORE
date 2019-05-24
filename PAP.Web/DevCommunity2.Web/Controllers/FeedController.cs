using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAP.Business.Managers;
using PAP.Business.Persistence.Repositories;
using PAP.Business.Repositories;
using PAP.Business.ViewModels;
namespace DevCommunity2.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly PublishAccountRepository _PublishAccountRepo;
        private readonly BaseManager _BaseManager;

        public FeedController(IPublishAccountRepository PublishAccountRepo, BaseManager baseManager)
        {
            _PublishAccountRepo = (PublishAccountRepository)PublishAccountRepo;
            _BaseManager = (BaseManager)baseManager;
        }

        // GET: Feed
        public ActionResult Index()
        {
            var result = _PublishAccountRepo.GetAccountPublishes().ToList();
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
        public ActionResult Create(FeedPostViewModel FeedPost, IFormFile File)
        {
            if (File != null)
            {
                FeedPost.FileName = File.FileName;
                FeedPost.ContentType = File.ContentType;

                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    FeedPost.PhotoBytes = ms.ToArray();
                }
            }

            try
            {
                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);
                 _PublishAccountRepo.AccountPublish(FeedPost, userId);
                _BaseManager.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
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