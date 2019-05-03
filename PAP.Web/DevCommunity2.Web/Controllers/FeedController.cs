using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevCommunity2.Web.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Feed()
        {
            return View();
        }
    }
}