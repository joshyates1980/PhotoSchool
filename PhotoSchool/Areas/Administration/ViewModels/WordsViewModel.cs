namespace PhotoSchool.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    using PhotoSchool.Models;
    using PhotoSchool.Areas.Administration.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;

    public class WordsViewModel : AdministrationViewModel, IMapFrom<Word>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}