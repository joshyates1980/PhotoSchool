namespace PhotoSchool.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using PhotoSchool.Data;
    using PhotoSchool.Controllers;

    public class HomeController : BaseController
    {
        public HomeController(IPhotoSchoolData data)
            : base(data)
        {

        }

        public ActionResult Navigation()
        {
            return View();
        }
    }
}