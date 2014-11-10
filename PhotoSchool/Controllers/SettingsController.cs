namespace PhotoSchool.Controllers
{
    using PhotoSchool.Data;
    using System.Web;

    public class SettingsController: BaseController
    {
        public SettingsController(IPhotoSchoolData data)
            : base(data)
        {
        }
    }
}