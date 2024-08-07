using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using VideoRental.DataAccess;

namespace VideoRental_OnlineStore.Data
{
    public class VideoRentalContextFactory : IDesignTimeDbContextFactory<VideoRentalDbContext>
    {
        public VideoRentalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VideoRentalDbContext>();

            // Get the connection string from the appsettings.json file
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new VideoRentalDbContext(optionsBuilder.Options);
        }
    }
}
