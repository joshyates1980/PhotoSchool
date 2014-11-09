namespace PhotoSchool.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Glosary
    {
        public Glosary()
        {
        this.Words = new HashSet<Word>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Word> Words { get; set; }
    }
}
