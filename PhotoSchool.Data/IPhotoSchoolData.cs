namespace PhotoSchool.Data
{
    using PhotoSchool.Models;
    using PhotoSchool.Data.Repositories;
    using PhotoSchool.Data.Contracts.Repository;

    public interface IPhotoSchoolData
    {
        IRepository<PhotoSchool.Models.Action> Actions { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Word> Words { get; }

        IRepository<CameraSetting> Settings { get; }

        IRepository<SettingMetric> Metrics { get; }

        IRepository<Like> Likes { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Photo> Photos { get; }

        IRepository<PhotoContest> PhotoContests { get; }

        IRepository<Tip> Tips { get; }

        IRepository<View> Views { get; }

        int SaveChanges();
    }
}
