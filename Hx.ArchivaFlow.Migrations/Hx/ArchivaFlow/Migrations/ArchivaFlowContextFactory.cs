using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hx.MenuSystem.Migrations
{
    internal class ArchivaFlowContextFactory : IDesignTimeDbContextFactory<ArchivaFlowMigrationsContext>
    {
        public ArchivaFlowMigrationsContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder =
                new DbContextOptionsBuilder<ArchivaFlowMigrationsContext>()
                .UseNpgsql(
                configuration.GetConnectionString("ArchivaFlow"));
            return new ArchivaFlowMigrationsContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
