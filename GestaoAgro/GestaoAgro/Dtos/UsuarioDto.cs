using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para o cadastro de usuário
    public class UsuarioDtos
    {
        // Nome completo do usuário
        [Required(ErrorMessage = "Nome completo é obrigatório")] // Campo obrigatório
        [MinLength(5, ErrorMessage = "Nome Completo deve ter no mínimo 5 caracteres")] // Validação para garantir que o nome tenha pelo menos 5 caracteres
        public string NomeCompleto { get; set; }

        // Nome de usuário para login
        [Required(ErrorMessage = "Nome de usuário é obrigatório")]  // Campo obrigatório
        [MinLength(5, ErrorMessage = "Nome de usuário deve ter no mínimo 5 caracteres")] // Validação para garantir que o nome de usuário tenha pelo menos 5 caracteres
        public string NomeUsuario { get; set; }

        // Senha do usuário
        [Required(ErrorMessage = "Senha é obrigatória")] // Campo obrigatório
        [MinLength(8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres")] // Validação para garantir que a senha tenha pelo menos 8 caracteres
        public string Senha { get; set; }

        // E-mail do usuário
        [Required(ErrorMessage = "E-mail é obrigatório")] // Campo obrigatório
        [EmailAddress(ErrorMessage = "E-mail inválido")] // Validação para garantir que o e-mail esteja no formato correto
        public string Email { get; set; }

        // CPF do usuário
        [Required(ErrorMessage = "CPF é obrigatório")] // Campo obrigatório
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CPF deve ter exatamente 14 caracteres")] // Validação para garantir que o CPF tenha exatamente 14 caracteres
        public string CPF { get; set; }

        // Data de nascimento do usuário
        [Required(ErrorMessage = "Data de nascimento é obrigatória")] // Campo obrigatório
        public DateTime? DataNascimento { get; set; }

        // Endereço do usuário
        [Required(ErrorMessage = "Endereço é obrigatório")] // Campo obrigatório
        public string Endereco { get; set; }
    }
}