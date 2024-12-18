using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Representa a tabela 'Pastagem' no banco de dados
    [Table("Pastagem")]  // Mapeia a classe para a tabela 'Pastagem' no banco de dados
    public class PastagemModel
    {
        // Identificador único da pastagem
        [Column("Id")]  // Define o nome da coluna correspondente no banco de dados
        public int Id { get; set; }

        // Área da pastagem em hectares ou outra unidade de medida
        [Column("AreaPastagem")]  // Define o nome da coluna correspondente no banco de dados
        public double AreaPastagem { get; set; }

        // Localização geográfica da pastagem (ex: coordenadas ou nome do campo)
        [Column("LocalizacaoPastagem")]  // Define o nome da coluna correspondente no banco de dados
        public string LocalizacaoPastagem { get; set; }

        // Período de tempo relacionado à pastagem (ex: mês ou estação do ano)
        [Column("Periodo")]  // Define o nome da coluna correspondente no banco de dados
        public int Periodo { get; set; }

        // Código do brinco do animal associado a essa pastagem
        [Column("fk_Animal_CodigoBrinco")]  // Define o nome da coluna correspondente no banco de dados
        public int CodigoBrinco { get; set; }

        // Relacionamento com o modelo 'AnimalModel' através do código de brinco
        public virtual AnimalModel Animal { get; set; }  // Relacionamento de navegação
    }
}