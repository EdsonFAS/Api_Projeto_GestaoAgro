using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    // Classe que representa os dados transferidos para o relacionamento entre Rebanho e Alimentação
    public class RebanhoAlimentacaoDto
    {
        // Identificador único para o relacionamento entre Rebanho e Alimentação
        [Required(ErrorMessage = "Id é obrigatório")] // Validação de campo obrigatório
        public int Id { get; set; }

        // Identificador único do rebanho associado à alimentação
        [Required(ErrorMessage = "Id do rebanho é obrigatório")] // Validação de campo obrigatório
        public int IdRebanho { get; set; }

        // Relacionamento com o modelo Rebanho (um Rebanho pode estar associado a várias Alimentações)
        public virtual RebanhoModel Rebanho { get; set; } // Relacionamento de navegação com RebanhoModel

        // Identificador único da alimentação associada ao rebanho
        [Required(ErrorMessage = "Id da alimentação é obrigatório")] // Validação de campo obrigatório
        public int IdAlimentacao { get; set; }

        // Relacionamento com o modelo Alimentação (uma alimentação pode ser associada a vários rebanhos)
        public virtual AlimentacaoModel Alimentacao { get; set; } // Relacionamento de navegação com AlimentacaoModel
    }
}