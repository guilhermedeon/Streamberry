using Microsoft.Extensions.DependencyInjection;
using Streamberry.Infra.Data.Models;
using Streamberry.Interfaces.Database;

namespace Streamberry.Infra.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraData(this IServiceCollection services)
        {
            services.AddSingleton<IStreamberryContext, StreamberryContext>();
            return services;
        }
    }
}