namespace PhotoSchool.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Glosary
    {
        [Key]
        public int Id { get; set; }

        private ICollection<Word> words;

        public Glosary()
        {
            this.words = new HashSet<Word>();
        }

        public virtual ICollection<Word> Words
        {
            get
            {
                return this.words;
            }
            set
            {
                this.words = value;
            }
        }
    }
}
