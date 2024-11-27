using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Usuario"), PrimaryKey(nameof(Id))]
    public class UsuarioModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_completo")]
        public string NomeCompleto { get; set; }

        [Column("nome_usuario")]
        public string NomeUsuario { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }
    }
}
