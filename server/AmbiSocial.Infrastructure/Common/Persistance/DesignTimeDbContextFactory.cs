namespace AmbiSocial.Infrastructure.Common.Persistance;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AmbiSocialDbContext>
{
    public AmbiSocialDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Common", "Persistance"))
                .AddJsonFile("appsettings.json")
                .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AmbiSocialDbContext>();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new AmbiSocialDbContext(optionsBuilder.Options);
    }
}