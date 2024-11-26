using System.ComponentModel.DataAnnotations;

namespace APi_aula06.Dtos
{
    public class ServidorSiape
    {
        [Required]
       public int id { get; set; }


        [Required]
        public string name { get; set; }


        [Required]
        public string cpf { get; set; }


        [Required]
        public int siape { get; set; }
    }
}
