using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Animal"), PrimaryKey(nameof(CodigoBrinco))]
    public class AnimalModel
    {
        [Column("codigo_brinco")]
        public int CodigoBrinco { get; set; }

        [Column("raca")]
        public required string Raca { get; set; }

        [Column("peso")]
        public double? Peso { get; set; }

        [Column("sexo")]
        public string? Sexo { get; set; }

        [Column("idade")]
        public int Idade { get; set; }
    }
}
