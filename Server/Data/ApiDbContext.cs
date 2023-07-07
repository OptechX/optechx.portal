using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Models;
using OptechX.Portal.Shared.Models.Engine.Applications;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Data
{
	public class ApiDbContext : DbContext
	{
        public DbSet<Application>? Applications { get; set; }

        // User
        public DbSet<UserAccount>? UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());

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

