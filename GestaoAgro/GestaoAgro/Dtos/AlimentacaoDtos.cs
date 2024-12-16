using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class AlimentacaoDtos
    {

        [Required]
        [MaxLength(255, ErrorMessage = "Fornecedor não pode ter mais de 255 caracteres")]
        public string Fornecedor { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nome da alimentação não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Quantidade em estoque deve ser maior que zero")]
        public double QuantidadeEstoque { get; set; }

        [Required]
        public DateTime DataValidade { get; set; }

        [Required]
        public DateTime DataEntrega { get; set; }

    }
}
