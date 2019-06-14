using System;
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

namespace DevCommunity2.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly PublishAccountRepository _PublishAccountRepo;
        private readonly BaseManager _BaseManager;
        private readonly HostingEnvironment _hostingEnvironment;

        public FeedController(IPublishAccountRepository PublishAccountRepo, BaseManager baseManager, IHostingEnvironment hostingEnvironment)
        {
            _PublishAccountRepo = (PublishAccountRepository)PublishAccountRepo;
            _BaseManager = baseManager;
            _hostingEnvironment = (HostingEnvironment)hostingEnvironment;
        }

        [HttpPost]
        public ActionResult FeedBackAccountIndex(int AccountPublishId)
        {
            var result = _PublishAccountRepo.GetAccountPublishFeedBack(AccountPublishId);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View();
            }
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
        public async Task<JsonResult> Create(FeedPostViewModel FeedPost, IFormFile File)
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

                _PublishAccountRepo.AddAccountPublish(FeedPost, userId);
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
        public JsonResult CreateFeedBack(FeedIndexFeedBackViewModel FeedBack)
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId);

            if (userId == null)
            {
                return Json(new { success = false, message = "erro" });
            }

            try
            {
                _PublishAccountRepo.AddFeedBack(FeedBack, userId);
                _BaseManager.SaveChanges();
                return Json(new { success = true, message = "sucess" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "erro" });
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