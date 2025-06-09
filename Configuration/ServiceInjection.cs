using Teste_Tecnico.Aplication.Interfaces;
using Teste_Tecnico.Aplication.Services;
using Teste_Tecnico.Infrastructure.Interfaces;
using Teste_Tecnico.Infrastructure.Repositories;

namespace Teste_Tecnico.Configuration
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticacaoService, AuthenticacaoSevice>();

            return services;
        }
    }
}
