namespace PhotoSchool.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using PhotoSchool.Models;

    public interface IPhotoSchoolDbContext : IDisposable
    {
        IDbSet<PhotoSchool.Models.Action> Actions { get; set; }

        IDbSet<Word> Words { get; set; }

        IDbSet<SettingMetric> Metrics { get; set; }

        IDbSet<CameraSetting> Settings { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Photo> Photos { get; set; }

        IDbSet<PhotoContest> PhotoContests { get; set; }

        IDbSet<Tip> Tips { get; set; }

        IDbSet<View> Views { get; set; }

        IDbSet<Feedback> Feedbacks { get; set; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
