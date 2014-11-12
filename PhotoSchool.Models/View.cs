namespace PhotoSchool.Models
{
    public class View
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
