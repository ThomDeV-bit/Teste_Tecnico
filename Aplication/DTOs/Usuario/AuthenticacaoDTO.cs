using System.ComponentModel.DataAnnotations;

namespace Teste_Tecnico.Aplication.DTOs.Usuario
{
    public class AuthenticacaoDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
