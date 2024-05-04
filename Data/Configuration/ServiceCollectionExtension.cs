using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data.Repository;
using Microsoft.Extensions.Configuration;

namespace Data.Configuration
{
    public static class ServiceCollectionExtension
    {

        public static void AddTournamentDbConfiguration(this IServiceCollection collection)
        {
            IConfiguration _config;

            using (var ServiceScoped = collection.BuildServiceProvider().CreateScope())
            {
                _config = ServiceScoped.ServiceProvider.GetService<IConfiguration>();
            }
            var ApllicationOptions = new ApllicationOptions();
            _config.GetSection(ApllicationOptions.Section).Bind(ApllicationOptions);

            collection.AddDbContext<TournamentContext>(options =>
            options.UseSqlServer(ApllicationOptions.ConnectionString));
        }

    }
}
