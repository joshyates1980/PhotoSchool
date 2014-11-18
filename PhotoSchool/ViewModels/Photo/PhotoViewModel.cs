namespace PhotoSchool.ViewModels.Photo
{
    using PhotoSchool.ViewModels.Actions;
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using PhotoSchool.ViewModels.Comment;

    public class PhotoViewModel : IMapFrom<Photo>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<View> Views { get; set; }
    }
}