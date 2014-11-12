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

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? Finish { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }
    }
}
