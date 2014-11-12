namespace PhotoSchool.Areas.Photos.ViewModels.Photo
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PhotoSchool.Areas.Photos.ViewModels.Actions;
    using PhotoSchool.Areas.Photos.ViewModels.Comment;
    using System.Web.Mvc;

    public class PhotoViewModel : IMapFrom<Photo>
    {
        public PhotoViewModel()
        {
            this.Actions = new List<ActionViewModel>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public int ViewCount { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        [UIHint("Action")]
        public ICollection<ActionViewModel> Actions { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}