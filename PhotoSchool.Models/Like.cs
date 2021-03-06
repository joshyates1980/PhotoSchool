﻿namespace PhotoSchool.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsPositive { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
