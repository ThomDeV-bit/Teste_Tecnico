using Microsoft.AspNetCore.Mvc;
using Teste_Tecnico.Aplication.DTOs.Usuario;
using Teste_Tecnico.Aplication.Interfaces;
using Teste_Tecnico.Domain.Entities;
using Teste_Tecnico.Infrastructure.Interfaces;

namespace Teste_Tecnico.Aplication.UseCases
{
    public class AuthenticacaoUseCase : IAuthenticacaoUseCase
    {
        private readonly IAuthenticacaoService _auth;
        private readonly IUsuarioRepository _usuarioRepository;
        public AuthenticacaoUseCase(IAuthenticacaoService authenticacao, IUsuarioRepository usuario)
        {
            _auth = authenticacao;
            _usuarioRepository = usuario;
        }

        public async Task<string> Authenticacao(AuthenticacaoDTO usuarioAuth)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.GetUsuario(usuarioAuth.Email);

                string token = _auth.Authenticacao(usuario.Email, usuarioAuth.Senha, usuario.Senha);

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
