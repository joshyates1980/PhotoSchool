namespace PhotoSchool.Controllers
{
    using PhotoSchool.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TipController : BaseController
    {
        public TipController(IPhotoSchoolData data)
            : base(data)
        {
        }

        public ActionResult AllTips(int? id)
        {
            var allTips = this.Data.Tips.All();
            return View(allTips);
        }
    }
}