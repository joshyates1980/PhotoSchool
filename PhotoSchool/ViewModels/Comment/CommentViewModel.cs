namespace PhotoSchool.ViewModels.Comment
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;
    using System;

    public class CommentViewModel: IMapFrom<Comment>
    {
        public string AuthorUsername { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}