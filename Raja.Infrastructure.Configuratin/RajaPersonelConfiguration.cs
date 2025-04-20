using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Raja.Application.Contract.IServices;
using Raja.Application.Services;
using Raja.Infrastracture.EFCore.Context;
using Raja.Infrastracture.EFCore.Repos;

namespace Raja.Infrastracture.Configuratin
{
    public partial class RajaPersonelConfiguration
    {
        public static void Configure(IServiceCollection services, string dbConnectionString)
        {
            ConfigureDatabase(services, dbConnectionString);
            ConfigureRepositoreis(services);
            ConfigureServices(services);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPersonelService, PersonelService>();
           
        }

        private static void ConfigureRepositoreis(IServiceCollection services)
        {
            services.AddTransient<IPersonelRepository, PersonelRepository>();
            
        }

        private static void ConfigureDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RajaPersonelContext>(option =>
            {
                option.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("Raja.Infrastracture.EFCore"));
            });
        }
    }

    // Migration Config
    public partial class RajaConfiguration
    {
        public static bool Migrate(IServiceProvider app)
        {
            try
            {
                var servicesScop = app.CreateScope();
                var services = servicesScop.ServiceProvider;
                var context = services.GetRequiredService<RajaPersonelContext>();
                context.Database.Migrate();
                servicesScop.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
