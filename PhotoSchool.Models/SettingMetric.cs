namespace PhotoSchool.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SettingMetric
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        public string ImageUrl { get; set; }

        public int CameraSettingId { get; set; }

        public virtual CameraSetting CameraSetting { get; set; }
    }
}
