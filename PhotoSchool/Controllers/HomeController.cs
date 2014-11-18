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
using PhotoSchool.Data.Contracts.Repository;
using PhotoSchool.Web.Infrastructure;
using PhotoSchool.ViewModels.Contact;
using Microsoft.AspNet.Identity;

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
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var model = new ContactViewModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel input)
        {
            if (ModelState.IsValid)
            {
                var userId = string.Empty;

                if (this.User.Identity.IsAuthenticated == true)
                {
                    userId = this.User.Identity.GetUserId();
                }
                else
                {
                    userId = null;
                }

                var feedback = new Feedback
                {
                    Name = input.Name,
                    Subject = input.Subject,
                    Email = input.Email,
                    Text = input.Text
                };

                this.Data.Feedbacks.Add(feedback);
                this.Data.SaveChanges();

                return this.RedirectToAction("About");
            }
            return this.View(input);
        }

        //public ActionResult Contact()
        //{
        //    var feedback = new Feedback();
        //    return View(feedback);
        //}

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