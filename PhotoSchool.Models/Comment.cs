namespace PhotoSchool.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
