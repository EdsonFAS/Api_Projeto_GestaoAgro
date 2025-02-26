using GestaoAgro.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para a produção de um animal
    public class ProducaoDto
    {
        // Identificador único da produção
        [Required(ErrorMessage = "Id é obrigatório")] // Validação de campo obrigatório
        public int Id { get; set; }

        // Tipo de produção (ex: leite, carne, ovos, etc.)
        [Required(ErrorMessage = "Tipo de produção é obrigatório")] // Validação de campo obrigatório
        public string TipoProducao { get; set; }

        // Data em que a produção ocorreu
        [Required(ErrorMessage = "Data da produção é obrigatória")] // Validação de campo obrigatório
        public DateTime Data { get; set; }

        // Quantidade produzida (quantidade de leite, carne, etc.)
        [Required(ErrorMessage = "Quantidade produzida é obrigatória")] // Validação de campo obrigatório
        public string QuantidadeProduzida { get; set; }

        // Código do brinco do animal associado à produção
        [Required(ErrorMessage = "Código do brinco é obrigatório")] // Validação de campo obrigatório
        public int CodigoBrinco { get; set; }

        // Relacionamento com o modelo Animal (uma produção está associada a um animal)
        public virtual AnimalModel Animal { get; set; } // Relacionamento de navegação com AnimalModel
    }
}