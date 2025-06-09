using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_Tecnico.Aplication.DTOs.Usuario;
using Teste_Tecnico.Aplication.Interfaces;

namespace Teste_Tecnico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticacaoController : ControllerBase
    {
        private readonly IAuthenticacaoUseCase _authenticacaoUseCase;
        public AuthenticacaoController(IAuthenticacaoUseCase authenticacaoUseCase) 
        {
            _authenticacaoUseCase = authenticacaoUseCase;
        }

        [HttpPost]

        public async Task<IActionResult> Authenticacao([FromBody] AuthenticacaoDTO userAuth)
        {
            string token = await _authenticacaoUseCase.Authenticacao(userAuth);

            return Ok(token);
        }
    }
}
