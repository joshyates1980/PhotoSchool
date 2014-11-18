namespace PhotoSchool.ViewModels.Tip
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class TipViewModel:IMapFrom<Tip>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}