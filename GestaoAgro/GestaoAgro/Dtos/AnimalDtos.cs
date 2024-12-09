using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class AnimalDtos
    {
        [Required]
        public int CodigoBrinco { get; set; }

        [Required]
        public string? Raca { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        public string? Sexo { get; set; }

        [Required]
        public int Idade { get; set; }
    }
}
