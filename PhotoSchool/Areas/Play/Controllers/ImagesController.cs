namespace PhotoSchool.Areas.Play.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PhotoSchool.Controllers;
    using PhotoSchool.Data;

    public class ImagesController : BaseController
    {
        public ImagesController(IPhotoSchoolData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult UploadImage()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image)
        {
            if (image != null)
            {
                image.SaveAs(Server.MapPath("~/Content/img/") + image.FileName);
                var photo = this.Data.Photos
                    .All()
                    .FirstOrDefault();
                photo.ImageUrl = "/Content/img/" + image.FileName;

                this.Data.SaveChanges();

                return RedirectToAction("PhotoDetails", "Photos", new { id = photo.Id });
            }

            return RedirectToAction("AllPhotos", "Photos");
        }
    }
}