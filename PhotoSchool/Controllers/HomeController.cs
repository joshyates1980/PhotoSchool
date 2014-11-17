using PhotoSchool.Data;
using PhotoSchool.Common;
using PhotoSchool.Models;
using PhotoSchool.ViewModels.Glosary;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSchool.Controllers
{
    public class HomeController : BaseController
    {
        private const int PageSize = 2;

        public HomeController(IPhotoSchoolData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var feedback = new Feedback();
            return View(feedback);
        }

        [HttpPost]
        public ActionResult Search(string text)
        {
            var wordsFound = this.Data.Words
                .All()
                .Where(x => x.Name.Contains(text) || x.Description.Contains(text))
                .Project()
                .To<WordsViewModel>()
                .ToList();

            //ViewBag.Pages = Math.Ceiling((double)wordsFound.Count() / PageSize);
            if (wordsFound.Count == 0)
            {
                return Content(GlobalConstants.NoGlossary);
            }

            return PartialView("_AllWordsPartial", wordsFound);
        }
    }
}