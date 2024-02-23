using Microsoft.Extensions.DependencyInjection;
using Streamberry.Domain.Abstractions;
using Streamberry.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamberry.Infra.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraData(this IServiceCollection services)
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
