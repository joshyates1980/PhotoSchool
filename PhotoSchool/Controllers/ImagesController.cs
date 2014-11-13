using PhotoSchool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSchool.Controllers
{
    public class ImagesController : BaseController
    {
        public ImagesController(IPhotoSchoolData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult UploadImage(string contestTitle)
        {
            ViewBag.ContestTitle = contestTitle;
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image, int contestId)
        {
            if (image != null)
            {
                image.SaveAs(Server.MapPath("~/Content/img/contests/") + image.FileName);
                var photo = this.Data.Photos.All().FirstOrDefault(x => x.PhotoContestId == contestId);
                photo.ImageUrl = "/Content/img/contests" + image.FileName;

                this.Data.SaveChanges();

                return RedirectToAction("PhotoDetails", "Photos", new { id = photo.Id });
            }

            return RedirectToAction("AllPhotos", "Photos");
        }
    }
}