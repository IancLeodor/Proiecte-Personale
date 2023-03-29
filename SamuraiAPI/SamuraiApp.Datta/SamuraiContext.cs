using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SamuraiApp.Domain;


namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        //public SamuraiContext(DbContextOptions<SamuraiContext> options)
            //:base(options)
        //{

       // }
        public DbSet<Samurai>  Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        //public DbSet<SamuraiBattleStats> SamuraiBattleStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB ; Initial Catalog = SamuraiAppData")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                        LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
               .HasMany(s => s.Battles)
               .WithMany(b => b.Samurais)
               .UsingEntity<BattleSamurai>
               (bs => bs.HasOne<Battle>().WithMany(),
               bs => bs.HasOne<Samurai>().WithMany())
               .Property(bs => bs.DateJoined)
               .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Horse>().ToTable("Horses");
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");
        }
    }
}
