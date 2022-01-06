using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hp_api
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        private void SeedIdentityData(ModelBuilder modelBuilder)
        {
            var adminRole = new IdentityRole()
            {
                Id = Environment.GetEnvironmentVariable("HPAPI_ADMINROLEID"),
                Name = "Admin",
                NormalizedName = "Admin"
            };

            modelBuilder.Entity<IdentityRole>().HasData(adminRole);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
