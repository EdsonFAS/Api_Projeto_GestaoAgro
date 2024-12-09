using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("RebanhoAlimentacao")]
    public class RebanhoAlimentacaoModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("fk_rebanho_id")]
        public int Rebanho { get; set; }

        [Column("fk_alimentacao_id")]
        public int Alimentacao { get; set; }
    }
}
