namespace PhotoSchool.Models
{
    using PhotoSchool.Models.Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CameraSetting
    {
        private ICollection<CameraSettingMetric> metrics;

        public CameraSetting()
        {
            this.metrics = new HashSet<CameraSettingMetric>();
        }

        [Key]
        public int Id { get; set; }

        public SettingType SettingType { get; set; }

        public string ShortDescription { get; set; }

        public string Explanation { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<CameraSettingMetric> Metrics
        {
            get
            {
                return this.metrics;
            }
            set
            {
                this.metrics = value;
            }
        }
    }
}
