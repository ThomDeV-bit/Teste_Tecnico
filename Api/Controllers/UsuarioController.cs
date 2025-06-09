using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Teste_Tecnico.Aplication.DTOs.Usuario;
using Teste_Tecnico.Aplication.Interfaces;

namespace Teste_Tecnico.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioUseCase _usuarioUseCase;
        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }


        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioDTO usuario)
        {
            try
            {
                bool novoUsuario = await _usuarioUseCase.CriarUsuario(usuario);

                if (!novoUsuario)
                {
                    return BadRequest("Email já cadastraso!");
                }

                return Ok(new { message = "Usuário criado com sucesso." });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<List<UsuarioListaDto>> ListaUsuarios()
        {
            try
            {
              return await _usuarioUseCase.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletaUsuario(int id)
        {
            try
            {
                await _usuarioUseCase.DeletaUsuario(id);

                return Ok(new { message = "Usuário Deletado com sucesso." });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> AlteraUsuario(int id, [FromBody] CriarUsuarioDTO usuario)
        {
            try
            {
                bool usuarioAlterado = await _usuarioUseCase.AlteraUsuario(id, usuario);

                if(!usuarioAlterado)
                    return NotFound(new { message = "Usuário não encontrado." });

                return Ok(new { message = "Usuário atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
