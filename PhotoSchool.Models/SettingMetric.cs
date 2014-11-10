namespace PhotoSchool.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SettingMetric
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        public int CameraSettingId { get; set; }

        public virtual CameraSetting CameraSetting { get; set; }
    }
}
