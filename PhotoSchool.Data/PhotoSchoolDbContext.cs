namespace PhotoSchool.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoSchool.Data.Contracts.Models;
    using PhotoSchool.Data.Migrations;
    using PhotoSchool.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class PhotoSchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public PhotoSchoolDbContext()
            : base("PhotoSchoolConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoSchoolDbContext, Configuration>());
        }

        public static PhotoSchoolDbContext Create()
        {
            return new PhotoSchoolDbContext();
        }

        public IDbSet<PhotoSchool.Models.Action> Actions { get; set; }

        public IDbSet<Word> Words { get; set; }

        public IDbSet<SettingMetric> Metrics { get; set; }

        public IDbSet<CameraSetting> Settings { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Photo> Photos { get; set; }

        public IDbSet<PhotoContest> PhotoContests { get; set; }

        public IDbSet<Tip> Tips { get; set; }

        public IDbSet<View> Views { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        
    }
}
