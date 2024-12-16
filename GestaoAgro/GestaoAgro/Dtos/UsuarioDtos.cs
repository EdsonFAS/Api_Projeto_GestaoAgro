using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class UsuarioDtos
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome Completo deve ter no mínimo 5 caracteres")]
        public string NomeCompleto { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Nome de usuário deve ter no mínimo 5 caracteres")]
        public string NomeUsuario { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres")]
        public string Senha { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Length(14, 14, ErrorMessage = "O CPF deve ter exatamente 14 caracteres")]
        public string CPF { get; set; }

        [Required]
        public DateTime? DataNascimento { get; set; }

        [Required]
        public string Endereco { get; set; }
    }
}
