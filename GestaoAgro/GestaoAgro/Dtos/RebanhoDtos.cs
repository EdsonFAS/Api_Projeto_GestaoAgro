using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class RebanhoDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        public int CodigoBrinco { get; set; }
        public virtual AnimalModel Animal { get; set; }
    }
}
