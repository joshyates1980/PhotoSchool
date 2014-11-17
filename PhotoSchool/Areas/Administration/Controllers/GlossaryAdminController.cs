namespace PhotoSchool.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using PhotoSchool.Data;
    using PhotoSchool.Models;
    using PhotoSchool.Areas.Administration.Controllers.Base;
    using PhotoSchool.Areas.Administration.ViewModels;

    using Kendo.Mvc.UI;

    using Model = PhotoSchool.Models.Word;
    using ViewModel = PhotoSchool.Areas.Administration.ViewModels.WordsViewModel;

    public class GlossaryAdminController : KendoGridAdministrationController
    {
        public GlossaryAdminController(IPhotoSchoolData data)
            : base(data)
        {
        }

        public ActionResult AllWords()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Words.All().Project().To<WordsViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Words.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null)
                model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.Words.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}