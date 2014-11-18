namespace PhotoSchool.Areas.Administration.Controllers.Base
{
    using PhotoSchool.Data;
    using PhotoSchool.Controllers;
    using System.Web.Mvc;
    using PhotoSchool.Common;

    [Authorize(Roles = GlobalConstants.Admin)]
    public abstract class AdminController : BaseController
    {
        public AdminController(IPhotoSchoolData data)
            : base(data)
        {
        }
    }
}