using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Representa a tabela 'RebanhoAlimentacao' no banco de dados
    [Table("RebanhoAlimentacao")]  // Mapeia a classe para a tabela 'RebanhoAlimentacao'
    public class RebanhoAlimentacaoModel
    {
        // Identificador único da relação entre rebanho e alimentação
        [Column("Id")]  // Mapeia a propriedade 'Id' para a coluna 'Id' no banco de dados
        public int Id { get; set; }

        // Chave estrangeira que faz referência ao Rebanho
        [Column("fk_Rebanho_IdRebanho")]  // Mapeia a coluna 'fk_Rebanho_IdRebanho'
        public int IdRebanho { get; set; }

        // Relacionamento com o modelo 'RebanhoModel', por meio da chave estrangeira 'IdRebanho'
        public virtual RebanhoModel Rebanho { get; set; }  // Relacionamento de navegação

        // Chave estrangeira que faz referência à Alimentação
        [Column("fk_Alimentacao_IdAlimentacao")]  // Mapeia a coluna 'fk_Alimentacao_IdAlimentacao'
        public int IdAlimentacao { get; set; }

        // Relacionamento com o modelo 'AlimentacaoModel', por meio da chave estrangeira 'IdAlimentacao'
        public virtual AlimentacaoModel Alimentacao { get; set; }  // Relacionamento de navegação
    }
}
