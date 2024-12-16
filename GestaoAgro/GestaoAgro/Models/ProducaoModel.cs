using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Producao")]
    public class ProducaoModel
    {
        [Key] // Define como chave primária
        [Column("Id")]
        public int Id { get; set; }

        [Column("TipoProducao")]
        public string TipoProducao { get; set; }

        [Column("Data")]
        public DateTime Data { get; set; }

        [Column("QuantidadeProduzida")]
        public string QuantidadeProduzida { get; set; }

        [Column("fk_Animal_CodigoBrinco")]
        public int CodigoBrinco { get; set; }
        public virtual AnimalModel Animal { get; set; }
    }
}
