using Teste_Tecnico.Aplication.DTOs;
using Teste_Tecnico.Aplication.DTOs.Usuario;
using Teste_Tecnico.Domain.Entities;

namespace Teste_Tecnico.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> CriarUsuario(Usuario usuario);
        bool ConsultaEmailExistente(string email);
        Task<List<UsuarioListaDto>> ListarUsuarios();
        Task<Usuario> GetUsuario(string email);
        Task<bool> DeletaUsuario(int id);
        Task AlteraUsuario(int id, Usuario usuarioAlterado);
    }
}
