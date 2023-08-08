using LMS.DATA.Configuration;
using LMS.DATA.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.DATA
{
    public class LMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>()
                .Property(x => x.ModifiedBy)
                .IsRequired(false)
                ;

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Country> Country { get; set; } 
    }
}