namespace PhotoSchool.Data
{
    using PhotoSchool.Models;
    using PhotoSchool.Data.Repositories;
    using PhotoSchool.Data.Contracts.Repository;

    public interface IPhotoSchoolData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Word> Words { get; }

        int SaveChanges();
    }
}
