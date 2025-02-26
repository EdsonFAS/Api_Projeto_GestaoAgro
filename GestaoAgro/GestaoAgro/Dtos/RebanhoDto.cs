using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para o rebanho de animais
    public class RebanhoDto
    {
        // Identificador único do rebanho
        [Required(ErrorMessage = "Id do rebanho é obrigatório")] // Validação de campo obrigatório
        public int Id { get; set; }

        // Tipo de rebanho (ex: carneiro, vaca leiteira, etc.)
        [Required(ErrorMessage = "Tipo de rebanho é obrigatório")] // Validação de campo obrigatório
        public string Tipo { get; set; }

        // Destino do rebanho (ex: venda, abate, engorda, etc.)
        [Required(ErrorMessage = "Destino do rebanho é obrigatório")] // Validação de campo obrigatório
        public string Destino { get; set; }

        // Código do brinco do animal associado ao rebanho
        [Required(ErrorMessage = "Código do brinco é obrigatório")] // Validação de campo obrigatório
        public int CodigoBrinco { get; set; }

        // Relacionamento com o modelo Animal (um rebanho pode ter um ou mais animais)
        public virtual AnimalModel Animal { get; set; } // Relacionamento de navegação com AnimalModel
    }
}