namespace PhotoSchool.Data.Repositories.Base
{
    using System.Linq;
    using PhotoSchool.Data.Contracts;
    using PhotoSchool.Data.Contracts.Repository;
    using PhotoSchool.Data.Contracts.Models;
    using System.Data.Entity;

    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
    where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }
        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }
        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }
    }
}
