using ENIMS.DataObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ENIMS.Api.Installers
{
    public class DatabaseInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region connection string config
            //services.AddDbContext<MasterDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("MasterConnectionString")).EnableSensitiveDataLogging(true));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")).EnableSensitiveDataLogging(true));

            services.AddDbContext<ApplicationDbContext>(options => { });//set as per current tenant
            
            #endregion


            //Application
            services.AddScoped<IDatabaseTransaction, AppDatabaseTransaction>();
            services.AddScoped<IAppDbTransactionContext, AppDbTransactionContext>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();


		}
    }
}
