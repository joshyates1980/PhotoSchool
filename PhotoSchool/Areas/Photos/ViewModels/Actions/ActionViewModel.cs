namespace PhotoSchool.Areas.Photos.ViewModels.Actions
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;

    public class ActionViewModel : IMapFrom<Action>
    {
        public string Text { get; set; }

        public string ParentActions { get; set; }
    }
}