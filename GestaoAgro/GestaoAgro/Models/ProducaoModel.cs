using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Representa a tabela 'Producao' no banco de dados
    [Table("Producao")]  // Mapeia a classe para a tabela 'Producao' no banco de dados
    public class ProducaoModel
    {
        // Identificador único da produção (chave primária)
        [Key]  // Define como chave primária
        [Column("Id")]  // Mapeia a propriedade 'Id' para a coluna 'Id' no banco de dados
        public int Id { get; set; }

        // Tipo de produção realizada (ex: leite, carne, etc.)
        [Column("TipoProducao")]  // Mapeia a propriedade 'TipoProducao' para a coluna 'TipoProducao'
        public string TipoProducao { get; set; }

        // Data da produção (quando a produção foi realizada)
        [Column("Data")]  // Mapeia a propriedade 'Data' para a coluna 'Data'
        public DateTime Data { get; set; }

        // Quantidade produzida (ex: quantidade de leite ou carne)
        [Column("QuantidadeProduzida")]  // Mapeia a propriedade 'QuantidadeProduzida' para a coluna 'QuantidadeProduzida'
        public string QuantidadeProduzida { get; set; }

        // Código do brinco do animal associado à produção
        [Column("fk_Animal_CodigoBrinco")]  // Mapeia a chave estrangeira para a coluna 'fk_Animal_CodigoBrinco'
        public string CodigoBrinco { get; set; }

        // Relacionamento com o modelo 'AnimalModel' através do código de brinco
        public virtual AnimalModel Animal { get; set; }  // Relacionamento de navegação
    }
}