using Microsoft.Extensions.DependencyInjection;
using Streamberry.Application.Services;

namespace Streamberry.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<AvaliacaoService>();
            services.AddSingleton<UsuarioService>();
            services.AddSingleton<FilmeService>();
            services.AddSingleton<StreamingService>();
            services.AddSingleton<GeneroService>();
            return services;
        }
    }
}