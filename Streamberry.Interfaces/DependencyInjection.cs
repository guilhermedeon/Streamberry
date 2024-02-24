using Microsoft.Extensions.DependencyInjection;
using Streamberry.Domain.Abstractions;
using Streamberry.Interfaces.Database.Repositories;

namespace Streamberry.Interfaces
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInterfaces(this IServiceCollection services)
        {
            services.AddSingleton<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IFilmeRepository, FilmeRepository>();
            services.AddSingleton<IStreamingRepository, StreamingRepository>();
            services.AddSingleton<IGeneroRepository, GeneroRepository>();
            return services;
        }
    }
}