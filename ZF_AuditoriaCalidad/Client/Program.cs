using ZF_AuditoriaCalidad.Client.Repositorios;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ZF_AuditoriaCalidad.Client.Helpers;

namespace ZF_AuditoriaCalidad.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddHttpClient<HttpClientConToken>(
                cliente => cliente.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<HttpClientSinToken>(
               cliente => cliente.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddApiAuthorization();
        }

        // var builder = WebAssemblyHostBuilder.CreateDefault(args);
        // builder.RootComponents.Add<App>("app");

        // builder.Services.AddHttpClient("ZF_AuditoriaCalidad.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
        //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        // builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
        // .CreateClient("ZF_AuditoriaCalidad.ServerAPI"));



        // builder.Services.AddApiAuthorization()
        //     .AddAccountClaimsPrincipalFactory<CustomUserFactory>();            

        // ConfigureServices(builder.Services);

        // await builder.Build().RunAsync();
    

        //private static void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddOptions();
        //    services.AddScoped<IRepositorio, Repositorio>();
        //    services.AddAuthorizationCore();
        //}         
    }
}
