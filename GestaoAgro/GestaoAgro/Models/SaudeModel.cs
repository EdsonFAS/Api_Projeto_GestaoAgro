using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Mapeia a classe 'SaudeModel' para a tabela 'Saude' no banco de dados
    [Table("Saude")]  // Mapeamento da classe para a tabela 'Saude'
    public class SaudeModel
    {
        // Identificador único para o registro de saúde
        [Column("Id")]  // Mapeia a propriedade 'Id' para a coluna 'Id' na tabela 'Saude'
        public int Id { get; set; }

        // Nome do veterinário responsável pela verificação
        [Column("Veterinario")]  // Mapeia a propriedade 'Veterinario' para a coluna 'Veterinario'
        public string? Veterinario { get; set; }

        // Status da saúde do animal (ex: saudável, doente, etc.)
        [Column("Status")]  // Mapeia a propriedade 'Status' para a coluna 'Status'
        public string? Status { get; set; }

        // Estado do apetite do animal (ex: bom, ruim, normal)
        [Column("Apetite")]  // Mapeia a propriedade 'Apetite' para a coluna 'Apetite'
        public string Apetite { get; set; }

        // Temperatura corporal do animal durante a verificação
        [Column("Temperatura")]  // Mapeia a propriedade 'Temperatura' para a coluna 'Temperatura'
        public double Temperatura { get; set; }

        // Data em que a verificação de saúde foi realizada
        [Column("DataVerificacao")]  // Mapeia a propriedade 'DataVerificacao' para a coluna 'DataVerificacao'
        public DateTime DataVerificacao { get; set; }

        // Código do brinco do animal (chave estrangeira)
        [Column("fk_Animal_CodigoBrinco")]  // Mapeia a chave estrangeira para a tabela 'Animal'
        public string CodigoBrinco { get; set; }

        // Relacionamento de navegação com o modelo 'AnimalModel'
        public virtual AnimalModel Animal { get; set; }  // Relacionamento com o animal associado
    }
}