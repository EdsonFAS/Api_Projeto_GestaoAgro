using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class AlimentacaoDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Fornecedor { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public double QuantidadeEstoque { get; set; }

        [Required]
        public DateTime DataValidade { get; set; }

        [Required]
        public DateTime DataEntrega { get; set; }
    }
}
