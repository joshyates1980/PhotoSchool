namespace PhotoSchool.Models
{
    using System.Collections.Generic;

    public class Photo
    {
        public Photo()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
            this.Actions = new HashSet<Action>();
            this.Views = new HashSet<View>();
        }

        public int Id { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Action> Actions { get; set; }

        public virtual ICollection<View> Views { get; set; }

        public int PhotoContestId { get; set; }

        public virtual PhotoContest PhotoContest { get; set; }
    }
}
