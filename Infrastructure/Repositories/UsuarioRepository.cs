using Microsoft.EntityFrameworkCore;
using Teste_Tecnico.Aplication.DTOs.Usuario;
using Teste_Tecnico.Domain.Entities;
using Teste_Tecnico.Infrastructure.Data;
using Teste_Tecnico.Infrastructure.Interfaces;

namespace Teste_Tecnico.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDataContext _context;

        public UsuarioRepository(AppDataContext context)
        {
            _context = context;
        }
        public bool ConsultaEmailExistente(string email)
        {
            try
            {
                bool existe = false;

                var existeEmail = _context.Usuarios.FirstOrDefault(x => x.Email == email);

                if (existeEmail == null)
                {
                    return existe;
                }

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CriarUsuario(Usuario usuario)
        {
            try
            {
                Usuario novoUsuario = new Usuario
                {
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha
                };

                _context.Add(novoUsuario);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioListaDto>> ListarUsuarios()
        {
            try
            {
                var lista = await _context.Usuarios.OrderBy(x => x.Id).Select(x => new UsuarioListaDto(x.Id, x.Nome, x.Email)).ToListAsync();

                return  lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> GetUsuario(string email)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

                if (usuario == null)
                    throw new Exception("Usuario não cadastrado");

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeletaUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario == null)
                {
                    return false;
                }

                _context.Usuarios.Remove(usuario);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> AlteraUsuario(int id, Usuario usuarioAlterado)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario == null)
                    return false;

                usuario.Email = usuarioAlterado.Email;

                usuario.Nome = usuarioAlterado.Nome;

                usuario.Senha = usuarioAlterado.Senha;
               
                _context.Usuarios.Update(usuario);

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
