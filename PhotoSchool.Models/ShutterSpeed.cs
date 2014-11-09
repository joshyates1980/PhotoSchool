namespace PhotoSchool.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShutterSpeed
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }
    }
}
