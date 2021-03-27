using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGM.IntegracaoGeral.Api.Configuration;
using SGM.WebAPI.Core.Autenticacao;
using SGM.WebAPI.Core.Middlewares;

namespace SGM.IntegracaoGeral.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}		

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddCors(Configuration);			
			services.Configure<Urls>(Configuration);
			services.AddJwtConfiguration(Configuration);
			services.AddDependencyInjection();			
			services.AddSwaggerGenConfig();
		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseSwaggerConfig();
			app.UseRouting();

			app.UseCors("ApiCorsPolicy");

			app.UseAuthConfiguration();

			app.UseExceptionHandler(new ExceptionHandlerOptions
			{
				ExceptionHandler = new CustomExceptionMiddleware().Invoke
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
