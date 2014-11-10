namespace PhotoSchool.Models
{
    using PhotoSchool.Models.Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CameraSetting
    {
        public CameraSetting()
        {
            this.Metrics = new HashSet<SettingMetric>();
        }

        [Key]
        public int Id { get; set; }

        public SettingType SettingType { get; set; }

        public string ShortDescription { get; set; }

        public string Explanation { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<SettingMetric> Metrics { get; set; }
    }
}
