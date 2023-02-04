using DesafioPratico.AutoGlass.Domain.Interfaces.Notificacoes;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository;
using DesafioPratico.AutoGlass.Domain.Interfaces.Services;
using DesafioPratico.AutoGlass.Domain.Notificacoes;
using DesafioPratico.AutoGlass.Infra.Context;
using DesafioPratico.AutoGlass.Infra.Repository;
using DesafioPratico.AutoGlass.Service.Services;

namespace DesafioPratico.AutoGlass.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
