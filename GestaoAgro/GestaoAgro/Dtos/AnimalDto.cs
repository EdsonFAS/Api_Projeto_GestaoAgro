using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para o modelo de Animal
    public class AnimalDtos
    {
        // Código de identificação do brinco do animal
        [Required(ErrorMessage = "Código de brinco é obrigatório")] // Validação de campo obrigatório
        public int CodigoBrinco { get; set; }

        // Raça do animal
        [Required(ErrorMessage = "Raça do animal é obrigatória")] // Validação de campo obrigatório
        public string? Raca { get; set; }

        // Peso do animal
        [Required(ErrorMessage = "Peso do animal é obrigatório")] // Validação de campo obrigatório
        public double Peso { get; set; }

        // Sexo do animal
        [Required(ErrorMessage = "Sexo do animal é obrigatório")] // Validação de campo obrigatório
        public string? Sexo { get; set; }

        // Idade do animal
        [Required(ErrorMessage = "Idade do animal é obrigatória")] // Validação de campo obrigatório
        public int Idade { get; set; }
    }
}