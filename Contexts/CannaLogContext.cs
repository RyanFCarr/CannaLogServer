using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Contexts
{
    public class CannaLogContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<GrowLog> GrowLogs { get; set; }
        public DbSet<Additive> Additives { get; set; }
        public DbSet<AdditiveAdjustment> AdditiveAdjustments { get; set; }
        public DbSet<AdditiveDosage> AdditiveDosages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = string.Format(
                "Data Source={0};Database={1};User Id={2};Password={3};",
                Environment.GetEnvironmentVariable("MYSQL_SOURCE"),
                Environment.GetEnvironmentVariable("MYSQL_DATABASE"),
                Environment.GetEnvironmentVariable("MYSQL_USER"),
                Environment.GetEnvironmentVariable("MYSQL_PASSWORD")
                );

            var dbServerVersion = ServerVersion.AutoDetect(conn);
            optionsBuilder.UseMySql(conn, dbServerVersion)
        #if DEBUG
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
        #endif
            ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Plant
            modelBuilder.Entity<Plant>()
                .Property(p => p.TargetPH)
                .HasPrecision(3, 1);
            #endregion
            #region GrowLog
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.AirTemperature)
                .HasPrecision(4, 1);
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.FinalPH)
                .HasPrecision(3, 1);
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.GrowMediumTemperature)
                .HasPrecision(4, 1);
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.Humidity)
                .HasPrecision(3, 1);
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.InitialPH)
                .HasPrecision(3, 1);
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.LightHeight)
                .HasPrecision(4, 1);
            modelBuilder.Entity<GrowLog>()
                .Property(p => p.PlantHeight)
                .HasPrecision(4, 1);
            #endregion
            #region Additives
            // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            modelBuilder.Entity<Additive>()
                .HasData(new Additive[] {
                    new Additive{ Id = 1, Brand = "General Hydroponics", Name = "Micro", Type = "NUTES" },
                    new Additive{ Id = 2, Brand = "General Hydroponics", Name = "Bloom", Type = "NUTES" },
                    new Additive{ Id = 3, Brand = "General Hydroponics", Name = "CaliMag", Type = "NUTES" },
                    new Additive{ Id = 4, Brand = "General Hydroponics", Name = "PH Up", Type = "PH" },
                    new Additive{ Id = 5, Brand = "General Hydroponics", Name = "PH Down", Type = "PH" },
                    new Additive{ Id = 6, Brand = "Botanicare", Name = "Hydroguard", Type = "ROOT SUPPLEMENT" }
                });
            modelBuilder.Entity<AdditiveDosage>()
                .Property(p => p.Amount)
                .HasPrecision(8, 3);
            #endregion
        }
    }
}
