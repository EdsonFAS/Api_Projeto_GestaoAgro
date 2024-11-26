using System.ComponentModel.DataAnnotations.Schema;

namespace APi_aula06.Model
{
    [Table("servidor")]
    public class ServidorModel
    {
        [Column("id_ser")]
        public int id { get; set; }

        [Column("nome_ser")]
        public string name { get; set; }

        [Column("cpf_ser")]
        public string cpf { get; set; }

        [Column("siape_ser")]
        public int siape { get; set; }
    }
}
