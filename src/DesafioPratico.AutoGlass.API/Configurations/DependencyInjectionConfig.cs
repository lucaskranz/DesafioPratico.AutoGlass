using DesafioPratico.AutoGlass.Infra.Context;

namespace DesafioPratico.AutoGlass.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
     
            return services;
        }
    }
}
