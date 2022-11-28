using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ENIMS.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		private readonly string _policyName = "CorsPolicy";
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.InstallServicesInAssembly(Configuration);
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddCors(options =>
			{
				options.AddPolicy(_policyName,
					builder => builder.WithOrigins(
					"http://localhost:3000",
					"http://localhost:3001",
					"http://localhost:3002",
					"http://localhost:2021",
					"http://svdccbe01:2186",
					"http://svsfclust01:5320",
					"http://svsfclust01:5200",
					"http://svhqdts01:5895",
					"http://localhost:8000",
					"https://eprocurement.ethiopianairlines.com",
					"https://eprocrumentbackoffice-web.conveyor.cloud",
					"http://localhost:5200")
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});

			//services.AddCors();


			services.AddDistributedMemoryCache();

			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(60);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});

			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
			});

			



		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostEnvironment env)
		{

			app.UseSession();
			#region global cors policy
			//app.UseCors();
			//app.UseCors(MyAllowSpecificOrigins);

			// global cors policy		


			app.UseAuthentication();

			app.UseCors(_policyName);

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			//Exception
			app.ConfigureCustomExceptionMiddleware();
			#endregion

			#region swager config
			app.UseSwagger();
			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "PMS API V1");
				c.RoutePrefix = string.Empty;
				c.DocExpansion(DocExpansion.None);

			});
			#endregion


			app.UseHttpsRedirection();
			//app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseMvc();
		}
	}
}
