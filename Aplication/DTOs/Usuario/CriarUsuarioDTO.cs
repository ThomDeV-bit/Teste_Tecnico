using System.ComponentModel.DataAnnotations;


namespace Teste_Tecnico.Aplication.DTOs.Usuario
{
    public class CriarUsuarioDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Nome precisa ter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!")]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}
