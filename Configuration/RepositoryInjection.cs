using Teste_Tecnico.Infrastructure.Repositories;
using Teste_Tecnico.Infrastructure.Interfaces;


namespace Teste_Tecnico.Configuration
{
    public static class RepositoryInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
