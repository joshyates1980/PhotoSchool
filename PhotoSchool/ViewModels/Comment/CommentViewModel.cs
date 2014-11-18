namespace PhotoSchool.ViewModels.Comment
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel: IMapFrom<Comment>
    {
        [Required]
        public string AuthorUsername { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}