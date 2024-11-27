using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class AnimalDtos
    {
        [Required]
        public int codigo_brinco { get; set; }

        [Required]
        public string raca { get; set; }

        [Required]
        public double peso { get; set; }

        [Required]
        public string sexo { get; set; }

        [Required]
        public int idade { get; set; }
    }
}
