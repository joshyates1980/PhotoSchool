namespace PhotoSchool.Controllers
{
    using PhotoSchool.Data;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using PhotoSchool.ViewModels.Glosary;
    using PhotoSchool.ViewModels.Settings;
    using System.Net;

    public class SettingsController: BaseController
    {
        public SettingsController(IPhotoSchoolData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult ApertureSettings()
        {
            var aperture = this.Data.Settings.GetById(1);

            var apertureModel = new SettingViewModel
            {
                Id = aperture.Id,
                SettingType = Models.Enumerations.SettingType.Aperture,
                ShortDescription = aperture.ShortDescription,
                ImageUrl = aperture.ImageUrl,
                Explanation = aperture.Explanation
            };
           
            return View(apertureModel);
        }

        [HttpGet]
        public ActionResult ExposureSettings()
        {
            var exposure = this.Data.Settings.GetById(2);

            var exposureModel = new SettingViewModel
            {
                Id = exposure.Id,
                SettingType = Models.Enumerations.SettingType.Exposure,
                ShortDescription = exposure.ShortDescription,
                ImageUrl = exposure.ImageUrl,
                Explanation = exposure.Explanation
            };

            return View(exposureModel);
        }

        [HttpGet]
        public ActionResult IsoSettings()
        {
            var iso = this.Data.Settings.GetById(3);

            var isoModel = new SettingViewModel
            {
                Id = iso.Id,
                SettingType = Models.Enumerations.SettingType.ISO,
                ShortDescription = iso.ShortDescription,
                ImageUrl = iso.ImageUrl,
                Explanation = iso.Explanation
            };

            return View(isoModel);
        }

        [HttpGet]
        public ActionResult ShutterSpeedSettings()
        {
            var shutterSpeed = this.Data.Settings.GetById(4);

            var shutterSpeedModel = new SettingViewModel
            {
                Id = shutterSpeed.Id,
                SettingType = Models.Enumerations.SettingType.ShutterSpeed,
                ShortDescription = shutterSpeed.ShortDescription,
                ImageUrl = shutterSpeed.ImageUrl,
                Explanation = shutterSpeed.Explanation
            };

            return View(shutterSpeedModel);
        }
    }
}