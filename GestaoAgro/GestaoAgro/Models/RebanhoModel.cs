using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Rebanho")]
    public class RebanhoModel
    {
        [Key] // Define como chave primária
        [Column("IdRebanho")]
        public int Id { get; set; }

        [Column("Tipo")]
        public string Tipo { get; set; }

        [Column("Destino")]
        public string Destino { get; set; }

        [Column("fk_Animal_CodigoBrinco")]
        public int CodigoBrinco { get; set; }
        public virtual AnimalModel Animal { get; set; }
    }
}
