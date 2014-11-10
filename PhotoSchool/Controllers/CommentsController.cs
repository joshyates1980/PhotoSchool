namespace PhotoSchool.Controllers
{
    using PhotoSchool.Data;
    using System.Web.Mvc;

    public class CommentsController : BaseController
    {
        public CommentsController(IPhotoSchoolData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}