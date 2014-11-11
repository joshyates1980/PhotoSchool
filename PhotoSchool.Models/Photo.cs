namespace PhotoSchool.Models
{
    using System.Collections.Generic;

    public class Photo
    {
        public Photo()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public string PhotoContestId { get; set; }

        public virtual PhotoContest PhotoContest { get; set; }
    }
}
