using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class Controle_pastagem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double AreaPastagem { get; set; }

        [Required]
        public string LocalizacaoPastagem { get; set; }

        [Required]
        public int Periodo { get; set; }

        [Required]
        public int CodigoBrinco { get; set; }
        public virtual AnimalModel Animal { get; set; }
    }
}
