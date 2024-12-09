using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NomeCompleto")]
        public string? NomeCompleto { get; set; }

        [Column("NomeUsuario")]
        public string? NomeUsuario { get; set; }

        [Column("Senha")]
        public string? Senha { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("CPF")]
        public string? CPF { get; set; }

        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }
    }
}
