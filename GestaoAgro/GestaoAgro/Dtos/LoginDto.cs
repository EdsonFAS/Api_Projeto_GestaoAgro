using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class LoginDto
    {
        [Required]
        [MinLength(5)]
        public required string NomeUsuario { get; set; }

        [Required]
        [MinLength(5)]
        public required string senha { get; set; }
        
    }
}
