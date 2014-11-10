namespace PhotoSchool.ViewModels.Glosary
{
    using PhotoSchool.Models;
    using PhotoSchool.Web.Infrastructure.Mapping;

    public class WordsViewModel: IMapFrom<Word>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}