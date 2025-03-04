using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para o controle de pastagem
    public class PastagemDtos
    {
        // Identificador único do controle de pastagem
        [Required(ErrorMessage = "Id é obrigatório")] // Validação de campo obrigatório
        public int Id { get; set; }

        // Área total da pastagem
        [Required(ErrorMessage = "Área da pastagem é obrigatória")] // Validação de campo obrigatório
        public double AreaPastagem { get; set; }

        // Localização da pastagem
        [Required(ErrorMessage = "Localização da pastagem é obrigatória")] // Validação de campo obrigatório
        public string LocalizacaoPastagem { get; set; }

        // Período de uso da pastagem (em dias, meses, etc.)
        [Required(ErrorMessage = "Período é obrigatório")] // Validação de campo obrigatório
        public int Periodo { get; set; }

        // Código do brinco do animal associado à pastagem
        [Required(ErrorMessage = "Código do brinco é obrigatório")] // Validação de campo obrigatório
        public String CodigoBrinco { get; set; }

        // Relacionamento com o modelo Animal (um controle de pastagem pode estar associado a um animal)
        public virtual AnimalModel Animal { get; set; } // Relacionamento de navegação com AnimalModel
    }
}