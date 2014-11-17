using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSchool.Areas.Play.Controllers
{
    public class PlayController : Controller
    {
        // GET: Play/Play
        public ActionResult PlayPhoto()
        {
            return View();
        }
    }
}