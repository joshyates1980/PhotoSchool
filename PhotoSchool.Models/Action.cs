namespace PhotoSchool.Models
{
    public class Action
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string ParentActions { get; set; }

        public int PhotoContestId { get; set; }

        public virtual PhotoContest PhotoContest { get; set; }
    }
}
