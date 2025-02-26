using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para a alimentação
    public class AlimentacaoDtos
    {
        // Propriedade que armazena o fornecedor da alimentação
        [Required(ErrorMessage = "Fornecedor é obrigatório")] // Validação de campo obrigatório
        [MaxLength(255, ErrorMessage = "Fornecedor não pode ter mais de 255 caracteres")] // Validação do tamanho máximo do fornecedor
        public string Fornecedor { get; set; }

        // Propriedade que armazena o nome da alimentação
        [Required(ErrorMessage = "Nome da alimentação é obrigatório")] // Validação de campo obrigatório
        [MaxLength(100, ErrorMessage = "Nome da alimentação não pode ter mais de 100 caracteres")] // Validação do tamanho máximo do nome
        public string Nome { get; set; }

        // Propriedade que armazena a quantidade em estoque da alimentação
        [Required(ErrorMessage = "Quantidade em estoque é obrigatória")]  // Validação de campo obrigatório
        [Range(0.01, double.MaxValue, ErrorMessage = "Quantidade em estoque deve ser maior que zero")] // Validação do valor da quantidade (deve ser maior que zero)
        public double QuantidadeEstoque { get; set; }

        // Propriedade que armazena a data de validade da alimentação
        [Required(ErrorMessage = "Data de validade é obrigatória")] // Validação de campo obrigatório
        public DateTime DataValidade { get; set; }

        // Propriedade que armazena a data de entrega da alimentação
        [Required(ErrorMessage = "Data de entrega é obrigatória")] // Validação de campo obrigatório
        public DateTime DataEntrega { get; set; }
    }
}