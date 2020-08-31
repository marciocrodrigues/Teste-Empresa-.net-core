using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Abastecimentos;
using TesteBitzen.DOMAIN.Interfaces.Relatorios;
using TesteBitzen.DOMAIN.Interfaces.Usuarios;
using TesteBitzen.DOMAIN.Interfaces.Veiculos;
using TesteBitzen.DOMAIN.Services.Abastecimentos;
using TesteBitzen.DOMAIN.Services.Relatorios;
using TesteBitzen.DOMAIN.Services.Usuarios;
using TesteBitzen.DOMAIN.Services.Veiculos;
using TesteBitzen.INFRA.Repositories.Abastecimentos;
using TesteBitzen.INFRA.Repositories.Usuarios;
using TesteBitzen.INFRA.Repositories.Veiculos;

namespace TesteBitzen.API.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IAbastecimentoRepository, AbastecimentoRepository>();
            services.AddScoped<IAbastecimentoService, AbastecimentoService>();
            services.AddScoped<IRelatoriosService, RelatorioService>();

            return services;
        }
    }
}
