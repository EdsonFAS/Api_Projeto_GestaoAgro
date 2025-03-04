using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Representa a tabela 'Rebanho' no banco de dados
    [Table("Rebanho")]  // Mapeia a classe para a tabela 'Rebanho' no banco de dados
    public class RebanhoModel
    {
        // Identificador único para o rebanho
        [Key]  // Define a propriedade 'Id' como chave primária
        [Column("IdRebanho")]  // Mapeia a propriedade 'Id' para a coluna 'IdRebanho' no banco de dados
        public int Id { get; set; }

        // Tipo do rebanho (ex: gado de corte, gado leiteiro, etc.)
        [Column("Tipo")]  // Mapeia a propriedade 'Tipo' para a coluna 'Tipo' no banco de dados
        public string Tipo { get; set; }

        // Destino do rebanho (ex: abate, reprodução, venda, etc.)
        [Column("Destino")]  // Mapeia a propriedade 'Destino' para a coluna 'Destino' no banco de dados
        public string Destino { get; set; }

        // Código de identificação do animal (chave estrangeira para a tabela 'Animal')
        [Column("fk_Animal_CodigoBrinco")]  // Mapeia a chave estrangeira 'CodigoBrinco' para a coluna 'fk_Animal_CodigoBrinco'
        public string CodigoBrinco { get; set; }

        // Relacionamento de navegação com o modelo 'AnimalModel'
        public virtual AnimalModel Animal { get; set; }  // Permite navegar para o animal associado
    }
}