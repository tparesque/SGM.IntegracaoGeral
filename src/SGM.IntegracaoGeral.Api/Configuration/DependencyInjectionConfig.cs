using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SGM.IntegracaoGeral.Api.Extensions;
using SGM.IntegracaoGeral.Api.Interface;
using SGM.IntegracaoGeral.Api.Services;
using SGM.IntegracaoGeral.Api.Usuario;

namespace SGM.IntegracaoGeral.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ISolicitarConcertoIluminacaoService, SolicitarConcertoIluminacaoService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ISolicitarIsencaoIptuService, SolicitarIsencaoIptuService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IEstadoService, EstadoService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IMunicipioService, MunicipioService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IUsuarioService, UsuarioService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ISalarioServidorService, SalarioServidorService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            
        }
    }
}
