namespace PhotoSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PhotoContest
    {
        public PhotoContest()
        {
            this.Photos = new HashSet<Photo>();
            this.Participants = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime Finish { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }
    }
}
