using GestaoAgro.Model;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class RebanhoAlimentacaoDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdRebanho { get; set; }
        public virtual RebanhoModel Rebanho { get; set; }

        [Required]
        public int IdAlimentacao { get; set; }
        public virtual AlimentacaoModel Alimentacao { get; set; }
    }
}
