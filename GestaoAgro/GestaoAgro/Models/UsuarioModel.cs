using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Mapeia a classe 'UsuarioModel' para a tabela 'Usuario' no banco de dados
    [Table("Usuario")]  // Define que esta classe representa a tabela 'Usuario' no banco de dados
    public class UsuarioModel
    {
        // Propriedade que representa o ID único do usuário
        [Column("Id")]  // Mapeia a propriedade 'Id' para a coluna 'Id' na tabela 'Usuario'
        public int Id { get; set; }

        // Propriedade que armazena o nome completo do usuário
        [Column("NomeCompleto")]  // Mapeia a propriedade 'NomeCompleto' para a coluna 'NomeCompleto' na tabela 'Usuario'
        public string? NomeCompleto { get; set; }

        // Propriedade que armazena o nome de usuário (nome de login)
        [Column("NomeUsuario")]  // Mapeia a propriedade 'NomeUsuario' para a coluna 'NomeUsuario' na tabela 'Usuario'
        public string? NomeUsuario { get; set; }

        // Propriedade que armazena a senha do usuário
        [Column("Senha")]  // Mapeia a propriedade 'Senha' para a coluna 'Senha' na tabela 'Usuario'
        public string? Senha { get; set; }

        // Propriedade que armazena o e-mail do usuário
        [Column("Email")]  // Mapeia a propriedade 'Email' para a coluna 'Email' na tabela 'Usuario'
        public string? Email { get; set; }

        // Propriedade que armazena o CPF do usuário
        [Column("CPF")]  // Mapeia a propriedade 'CPF' para a coluna 'CPF' na tabela 'Usuario'
        public string? CPF { get; set; }

        // Propriedade que armazena a data de nascimento do usuário
        [Column("DataNascimento")]  // Mapeia a propriedade 'DataNascimento' para a coluna 'DataNascimento' na tabela 'Usuario'
        public DateTime DataNascimento { get; set; }

        // Propriedade que armazena o endereço do usuário
        [Column("Endereco")]  // Mapeia a propriedade 'Endereco' para a coluna 'Endereco' na tabela 'Usuario'
        public string Endereco { get; set; }
    }
}
