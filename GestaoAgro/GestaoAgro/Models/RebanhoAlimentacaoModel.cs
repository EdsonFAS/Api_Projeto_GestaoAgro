using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("RebanhoAlimentacao")]
    public class RebanhoAlimentacaoModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("fk_Rebanho_IdRebanho")]
        public int IdRebanho { get; set; }
        public virtual RebanhoModel Rebanho { get; set; }

        [Column("fk_Alimentacao_IdAlimentacao")]
        public int IdAlimentacao { get; set; }
        public virtual AlimentacaoModel Alimentacao { get; set; }
    }
}
