using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para a saúde dos animais
    public class SaudeDtos
    {
        // Identificador único da entrada de saúde do animal
        [Required(ErrorMessage = "Id é obrigatório")] // Validação de campo obrigatório
        public int Id { get; set; }

        // Nome do veterinário responsável pela verificação de saúde
        [Required(ErrorMessage = "Nome do veterinário é obrigatório")] // Validação de campo obrigatório
        public string? Veterinario { get; set; }

        // Status de saúde do animal (ex: saudável, doente, em tratamento, etc.)
        [Required(ErrorMessage = "Status de saúde é obrigatório")] // Validação de campo obrigatório
        public string? Status { get; set; }

        // Apetite do animal durante a verificação (ex: bom, fraco, sem apetite, etc.)
        [Required(ErrorMessage = "Apetite do animal é obrigatório")] // Validação de campo obrigatório
        public string Apetite { get; set; }

        // Temperatura do animal durante a verificação (em graus Celsius)
        [Required(ErrorMessage = "Temperatura é obrigatória")]  // Validação de campo obrigatório
        public double Temperatura { get; set; }

        // Data da verificação de saúde do animal
        [Required(ErrorMessage = "Data da verificação é obrigatória")]  // Validação de campo obrigatório
        public DateTime DataVerificacao { get; set; }

        // Código do brinco do animal que está sendo verificado
        [Required(ErrorMessage = "Código do brinco é obrigatório")]  // Validação de campo obrigatório
        public int CodigoBrinco { get; set; }

        // Relacionamento com o modelo Animal (a saúde é associada a um animal específico)
        public virtual AnimalModel Animal { get; set; } // Relacionamento de navegação com AnimalModel
    }
}