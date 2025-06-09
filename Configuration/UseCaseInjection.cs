using Teste_Tecnico.Aplication.Interfaces;
using Teste_Tecnico.Aplication.UseCases;

namespace Teste_Tecnico.Configuration
{
    public static class UseCaseInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();

            services.AddScoped<IAuthenticacaoUseCase, AuthenticacaoUseCase>();

            return services;
        }
    }
}
