namespace PhotoSchool.Areas.Administration.Base
{
    using PhotoSchool.Data;
    using PhotoSchool.Controllers;

    // [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IPhotoSchoolData data)
            : base(data)
        {
        }
    }
}