using Microsoft.EntityFrameworkCore;
using SealGame.Core.Domain;


namespace SealGame.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options) : base(options) { }

        public DbSet<Seal> Seals { get; set; }
        public DbSet<Töötaja> Töötajad { get; set; }
        public DbSet<Töötaja> Töötajad { get; set; }
        public DbSet<Töötaja> Töötajad { get; set; }
        public DbSet<Töötaja> Töötajad { get; set; }

    }
}
