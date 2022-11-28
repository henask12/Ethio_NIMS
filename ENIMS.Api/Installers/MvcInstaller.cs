using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using ENIMS.Common;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ENIMS.Api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
           //fluent validation
            services.AddMvc(setupAction: options =>
            {
				options.Filters.Add(typeof(AuthorizationAttribute));
				//options.Filters.Add<ValidationFilter>();
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(mvcconfigration => mvcconfigration.RegisterValidatorsFromAssemblyContaining<Startup>());
    

            // token jwt
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.ClientSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

			//swager config
			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
                //c.OperationFilter<SwaggerHeaderFilter>();
            });
        }
    }
}
