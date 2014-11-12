namespace PhotoSchool.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using PhotoSchool.Data.Repositories;
    using PhotoSchool.Models;
    using PhotoSchool.Data.Contracts.Repository;
    using PhotoSchool.Data.Repositories.Base;

    public class PhotoSchoolData : IPhotoSchoolData
    {
        private DbContext context;

        private IDictionary<Type, object> repositories;

        public PhotoSchoolData() :
            this(new PhotoSchoolDbContext())
        {
        }

        public PhotoSchoolData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<PhotoSchool.Models.Action> Actions
        {
            get
            {
                return this.GetRepository<PhotoSchool.Models.Action>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Word> Words
        {
            get
            {
                return this.GetRepository<Word>();
            }
        }

        public IRepository<SettingMetric> Metrics
        {
            get
            {
                return this.GetRepository<SettingMetric>();
            }
        }

        public IRepository<CameraSetting> Settings
        {
            get
            {
                return this.GetRepository<CameraSetting>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Photo> Photos
        {
            get
            {
                return this.GetRepository<Photo>();
            }
        }

        public IRepository<PhotoContest> PhotoContests
        {
            get
            {
                return this.GetRepository<PhotoContest>();
            }
        }

        public IRepository<Tip> Tips
        {
            get
            {
                return this.GetRepository<Tip>();
            }
        }

        public IRepository<View> Views
        {
            get
            {
                return this.GetRepository<View>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
