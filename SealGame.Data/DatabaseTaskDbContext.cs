using Microsoft.EntityFrameworkCore;
using SealGame.Core.Domain;


namespace SealGame.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options) : base(options) { }

        public DbSet<Seal> Seals { get; set; }
        public DbSet<SealSpecies> SealSpecies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SealSpecies>().HasData(
                    new SealSpecies
                    {
                        Id = 1,
                        Name = "Weddell Seal",
                        MaxHappiness = 100,
                        MaxHunger = 50,
                        MaxEnrichment = 80,
                        MaxCleanliness = 100,
                        Description = "imelik"
                    },
                    new SealSpecies
                    {
                        Id = 2,
                        Name = "Ringed Seal",
                        MaxHappiness = 90,
                        MaxHunger = 60,
                        MaxEnrichment = 85,
                        MaxCleanliness = 95,
                        Description = "rõngik"
                    },
                    new SealSpecies
                    {
                        Id = 3,
                        Name = "Harbor Seal",
                        MaxHappiness = 95,
                        MaxHunger = 55,
                        MaxEnrichment = 90,
                        MaxCleanliness = 100,
                        Description = "tavaline"
                        }
            );
        }

    }
}
