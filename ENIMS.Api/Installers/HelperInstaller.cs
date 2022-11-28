using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENIMS.Common;
using ENIMS.Core;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace ENIMS.Api.Installers
{
    public class HelperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
			// To list physical files from a path provided by configuration:

			//var fileSettingsSection = configuration.GetSection("FileSettings");
			//services.Configure<FileSettings>(fileSettingsSection);

			//var fileSettings = fileSettingsSection.Get<FileSettings>();

			//var physicalProvider = new PhysicalFileProvider(fileSettings.StoredFilesPath);

   //         services.AddSingleton<IFileProvider>(physicalProvider);
            //
            services.AddSingleton<ILoggerManager, LoggerManager>();
            //
            services.AddSingleton<IEmailSender, EmailSenderService>();
            //
            services.AddScoped<ITokenProvider, TokenProvider>();

            //
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IServiceUtility, ServiceUtility>();

            //configure
            services.Configure<Settings>(configuration.GetSection("Settings"));
        }
    }
}
