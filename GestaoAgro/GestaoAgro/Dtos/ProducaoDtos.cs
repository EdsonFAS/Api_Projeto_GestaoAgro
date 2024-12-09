using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class ProducaoDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string TipoProducao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string QuantidadeProduzida { get; set; }
    }
}
