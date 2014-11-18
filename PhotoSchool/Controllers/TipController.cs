namespace PhotoSchool.Controllers
{
    using PhotoSchool.Data;
    using PhotoSchool.ViewModels.Tip;
    using AutoMapper.QueryableExtensions;
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

        [HttpGet]
        public ActionResult AllTips(int? id)
        {
            var tips = this.Data.Tips.All().Select(x => new TipViewModel
            {
                Id = x.Id,
                Content = x.Content
            }).OrderBy(x => x.Id);
            ;
            return View(tips);
        }
    }
}