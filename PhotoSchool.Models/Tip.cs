namespace PhotoSchool.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } 
    }
}
