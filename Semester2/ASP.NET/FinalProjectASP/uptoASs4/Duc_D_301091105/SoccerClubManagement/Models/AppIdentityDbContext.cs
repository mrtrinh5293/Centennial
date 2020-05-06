using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SoccerClubManagement.Models
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }
    }
    //public class AppIdentityContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    //{
    //    public AppIdentityDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
    //        optionsBuilder.UseSqlite("Data Source=blog.db");

    //        return new AppIdentityDbContext(optionsBuilder.Options);
    //    }
    //}
}
