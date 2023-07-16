using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Models;
using OptechX.Portal.Shared.Models.Engine.Applications;
using OptechX.Portal.Shared.Models.Engine.Drivers;
using OptechX.Portal.Shared.Models.Forms;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Data
{
    public class ApiDbContext : DbContext
    {
        // Engine
        public DbSet<Application>? Applications { get; set; }
        public DbSet<Driver>? Drivers { get; set; }
        public DbSet<DriverCore>? DriverCores { get; set; }

        // User
        public DbSet<UserAccount>? UserAccounts { get; set; }

        // Forms
        public DbSet<WinReleaseApiResult>? WinReleaseApiResults { get; set; }
        public DbSet<WinEditionApiResult>? WinEditionApiResults { get; set; }
        public DbSet<WinVersionApiResult>? WinVersionApiResults { get; set; }
        public DbSet<WinArchApiResult>? WinArchApiResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new DriverCoreConfiguration());
            modelBuilder.ApplyConfiguration(new WinReleaseApiResultConfiguration());
            modelBuilder.ApplyConfiguration(new WinEditionApiResultConfiguration());
            modelBuilder.ApplyConfiguration(new WinVersionApiResultConfiguration());
            modelBuilder.ApplyConfiguration(new WinArchApiResultConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetSection("ApiDbContext:ConnectionString").Value!;

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
