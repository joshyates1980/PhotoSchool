namespace PhotoSchool.ViewModels.Tip
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;

    public class TipViewModel:IMapFrom<Tip>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}