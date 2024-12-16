using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class SaudeDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Veterinario { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        public string Apetite { get; set; }

        [Required]
        public double Temperatura { get; set; }

        [Required]
        public DateTime DataVerificacao { get; set; }

        [Required]
        public int CodigoBrinco { get; set; }
        public virtual AnimalModel Animal { get; set; }
    }
}
