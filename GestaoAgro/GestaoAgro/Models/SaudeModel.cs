using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Saude")]
    public class SaudeModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Veterinario")]
        public string? Veterinario { get; set; }

        [Column("Status")]
        public string? Status { get; set; }

        [Column("Apetite")]
        public string Apetite { get; set; }

        [Column("Temperatura")]
        public double Temperatura { get; set; }

        [Column("DataVerificacao")]
        public DateTime DataVerificacao { get; set; }

        [Column("fk_Animal_CodigoBrinco")]
        public int CodigoBrinco { get; set; }
        public virtual AnimalModel Animal { get; set; }
    }
}
