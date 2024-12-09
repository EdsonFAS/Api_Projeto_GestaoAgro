using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Alimentacao")]
    public class AlimentacaoModel
    {
        [Key] // Define como chave primária
        [Column("Id")]
        public int Id { get; set; }

        [Column("Fornecedor")]
        public string? Fornecedor { get; set; }

        [Column("Nome")]
        public string? Nome { get; set; }

        [Column("QuantidadeEstoque")]
        public double QuantidadeEstoque { get; set; }

        [Column("DataValidade")]
        public DateTime DataValidade { get; set; }

        [Column("DataEntrega")]
        public DateTime DataEntrega { get; set; }
    }
}
