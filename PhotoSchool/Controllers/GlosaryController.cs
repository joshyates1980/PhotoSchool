namespace PhotoSchool.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using PhotoSchool.Data;
    using PhotoSchool.Data.Contracts.Repository;
    using PhotoSchool.Models;
    using PhotoSchool.Data.Repositories.Base;
    using System;
    using PhotoSchool.ViewModels.Glosary;
    using AutoMapper.QueryableExtensions;

    public class GlosaryController : Controller
    {
        private IRepository<Word> words;
        private const int PageSize = 2;

        public GlosaryController():
            this(new GenericRepository<Word>(new PhotoSchoolDbContext()))
            {           
            }

        public GlosaryController(IRepository<Word> words)
        {
            this.words = words;
        }

        public ActionResult AllWords(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);
            var allWords = this.words.All().Select(x => new WordsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).OrderBy(x => x.Name);

            var articles = allWords.Skip((pageNumber - 1) * PageSize).Take(PageSize);
            ViewBag.Pages = Math.Ceiling((double)allWords.Count() / PageSize);
            return View(allWords);
        }
    }
}