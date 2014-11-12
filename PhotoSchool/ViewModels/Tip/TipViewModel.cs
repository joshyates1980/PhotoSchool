namespace PhotoSchool.ViewModels.Tip
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;

    public class TipViewModel : IMapFrom<Word>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}