namespace PhotoSchool.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    using PhotoSchool.Models;
    using PhotoSchool.Areas.Administration.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class WordsViewModel : AdministrationViewModel, IMapFrom<Word>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(15000, MinimumLength = 5)]
        public string Description { get; set; }
    }
}