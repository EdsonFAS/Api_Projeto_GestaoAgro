using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Dtos
{
    public class UsuarioDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int NomeCompleto { get; set; }

        [Required]
        public int NomeUsuario { get; set; }

        [Required]
        public int Senha { get; set; }

        [Required]
        public int Email { get; set; }

        [Required]
        public int CPF { get; set; }

        [Required]
        public int DataNascimento { get; set; }

        [Required]
        public int Endereco { get; set; }
    }
}
