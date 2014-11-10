namespace PhotoSchool.Models
{
    public class CameraSettingMetric
    {
        public int Id { get; set; }

        public int SettingMetricId { get; set; }

        public virtual SettingMetric SettingMetric { get; set; }

        public int CameraSettingId { get; set; }

        public virtual CameraSetting CameraSetting{ get; set; }
    }
}
