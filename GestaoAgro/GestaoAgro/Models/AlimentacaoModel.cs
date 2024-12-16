using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Representa a tabela 'Alimentacao' no banco de dados
    [Table("Alimentacao")]  // Define o nome da tabela no banco de dados
    public class AlimentacaoModel
    {
        // Identificador único da alimentação (chave primária)
        [Key] // Define como chave primária da tabela
        [Column("IdAlimentacao")]  // Define o nome da coluna correspondente no banco de dados
        public int Id { get; set; }

        // Nome do fornecedor da alimentação
        [Column("Fornecedor")]  // Define o nome da coluna correspondente no banco de dados
        public string? Fornecedor { get; set; }

        // Nome da alimentação (ex: ração, suplemento, etc.)
        [Column("Nome")]  // Define o nome da coluna correspondente no banco de dados
        public string? Nome { get; set; }

        // Quantidade de alimentação disponível em estoque
        [Column("QuantidadeEstoque")]  // Define o nome da coluna correspondente no banco de dados
        public double QuantidadeEstoque { get; set; }

        // Data de validade da alimentação
        [Column("DataValidade")]  // Define o nome da coluna correspondente no banco de dados
        public DateTime DataValidade { get; set; }

        // Data de entrega da alimentação
        [Column("DataEntrega")]  // Define o nome da coluna correspondente no banco de dados
        public DateTime DataEntrega { get; set; }
    }
}
