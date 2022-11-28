using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ENIMS.Api
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
