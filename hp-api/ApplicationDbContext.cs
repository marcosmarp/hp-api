using hp_api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace hp_api
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        private void SeedIdentityData(ModelBuilder modelBuilder)
        {
            var adminRole = new IdentityRole()
            {
                Id = Environment.GetEnvironmentVariable("HPAPI_ADMINROLEID"),
                Name = "admin",
                NormalizedName = "admin"
            };

            modelBuilder.Entity<IdentityRole>().HasData(adminRole);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
            .Property(e => e.AlternativeNames)
            .HasConversion<StringArrayConverter>();


            modelBuilder.Entity<Character>()
            .Property(e => e.AlternativeActors)
            .HasConversion<StringArrayConverter>();

            modelBuilder.Entity<Character>()
                .Property(e => e.BirthDate)
                .HasConversion<DateOnlyConverter>();

            modelBuilder.Entity<Character>()
                .HasOne(e => e.Patronus)
                .WithOne(e => e.Character)
                .HasForeignKey<Patronus>(p => p.CharacterId);

            modelBuilder.Entity<Character>()
                .HasOne(e => e.Wand)
                .WithOne(e => e.Character)
                .HasForeignKey<Wand>(p => p.CharacterId);

            SeedIdentityData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Ancestry> Ancestries { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Patronus> Patronus { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Wand> Wands { get; set; }
        public DbSet<WandCore> WandCores { get; set; }
        public DbSet<WandWood> WandWoods { get; set; }
    }
}

public class StringArrayConverter : ValueConverter<string[], string>
{
    public StringArrayConverter() : base(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
    { }
}

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}
