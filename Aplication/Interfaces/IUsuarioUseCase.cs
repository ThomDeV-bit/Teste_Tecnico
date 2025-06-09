using Teste_Tecnico.Aplication.DTOs.Usuario;

namespace Teste_Tecnico.Aplication.Interfaces
{
    public interface IUsuarioUseCase
    {
        Task<bool> CriarUsuario(CriarUsuarioDTO usuario);
        Task<List<UsuarioListaDto>> ListarUsuarios();
        Task<bool> DeletaUsuario(int id);
        Task AlteraUsuario(int Id, CriarUsuarioDTO usuario);
    }
}
