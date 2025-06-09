using Teste_Tecnico.Aplication.DTOs.Usuario;

namespace Teste_Tecnico.Aplication.Interfaces
{
    public interface IAuthenticacaoUseCase
    {
        Task<string> Authenticacao(AuthenticacaoDTO usuarioAuth);
    }
}
