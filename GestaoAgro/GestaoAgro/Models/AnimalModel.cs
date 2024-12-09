using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Animal")]
    public class AnimalModel
    {
        [Key] // Indica que esta é a chave primária
        [Column("CodigoBrinco")]
        public int CodigoBrinco { get; set; }

        [Column("Raca")]
        public string? Raca { get; set; }

        [Column("Peso")]
        public double? Peso { get; set; }

        [Column("Sexo")]
        public string? Sexo { get; set; }

        [Column("Idade")]
        public int Idade { get; set; }
    }
}
