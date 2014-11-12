namespace PhotoSchool.Areas.Photos.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    public class SubmitCommentViewModel
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public int PhotoId { get; set; }
    }
}