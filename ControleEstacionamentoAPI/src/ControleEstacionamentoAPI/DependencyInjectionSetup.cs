using ControleEstacionamento.Application.Interfaces;
using ControleEstacionamento.Application.Services;
using ControleEstacionamento.Data.Context;
using ControleEstacionamento.Data.Repository;
using ControleEstacionamento.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ControleEstacionamento.Api
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EstacionamentoDbContext>();
            services.AddScoped<IParametrizacaoRepository, ParametrizacaoRepository>();
            services.AddScoped<IParametrizacaoAppService, ParametrizacaoAppService>();
            services.AddScoped<IParametrizacaoGratuidadeRepository, ParametrizacaoGratuidadeRepository>();
            services.AddScoped<IParametrizacaoGratuidadeAppService, ParametrizacaoGratuidadeAppService>();
            services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
            services.AddScoped<IEstacionamentoAppService, EstacionamentoAppService>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IHistoricoAppService, HistoricoAppService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
