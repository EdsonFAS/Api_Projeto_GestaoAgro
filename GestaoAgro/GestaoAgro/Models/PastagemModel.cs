using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    [Table("Pastagem")]
    public class PastagemModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("AreaPastagem")]
        public double area_de_pastagem { get; set; }

        [Column("LocalizacaoPastagem")]
        public string LocalizacaoPastagem { get; set; }

        [Column("Periodo")]
        public int Periodo { get; set; }

        [Column("fk_Animal_CodigoBrinco")]
        public int CodigoBrinco { get; set; }
    }
}
