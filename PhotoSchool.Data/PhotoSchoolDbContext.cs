namespace PhotoSchool.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoSchool.Models;

    public class PhotoSchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public PhotoSchoolDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static PhotoSchoolDbContext Create()
        {
            return new PhotoSchoolDbContext();
        }
    }
}
