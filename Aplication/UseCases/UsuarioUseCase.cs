using Microsoft.AspNetCore.Mvc;
using Teste_Tecnico.Aplication.Communs;
using Teste_Tecnico.Aplication.DTOs.Usuario;
using Teste_Tecnico.Aplication.Interfaces;
using Teste_Tecnico.Domain.Entities;
using Teste_Tecnico.Infrastructure.Interfaces;

namespace Teste_Tecnico.Aplication.UseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> CriarUsuario(CriarUsuarioDTO usuario)
        {
            try
            {
                usuario.Senha = Utilitarios.HashSenhaUsuario(usuario.Senha);

                bool existeEmail = _usuarioRepository.ConsultaEmailExistente(usuario.Email);

                if (existeEmail)
                {
                    return false;
                }

                Usuario novoUsuario = new Usuario
                {
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha,
                };

                await _usuarioRepository.CriarUsuario(novoUsuario);

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
                return await _usuarioRepository.ListarUsuarios(); ;
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
                bool usuarioDeletado = await _usuarioRepository.DeletaUsuario(id);

                if (!usuarioDeletado)
                    throw new Exception("Erro ao deletar usuário!");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> AlteraUsuario(int id, CriarUsuarioDTO usuario)
        {
            try
            {
                Usuario usuarioAlterado = new Usuario
                {
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Senha = Utilitarios.HashSenhaUsuario(usuario.Senha),
                };

                return await _usuarioRepository.AlteraUsuario(id, usuarioAlterado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
