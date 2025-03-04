using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAgro.Model
{
    // Representa a tabela 'Animal' no banco de dados
    [Table("Animal")]  // Mapeia a classe para a tabela 'Animal' no banco de dados
    public class AnimalModel
    {
        // Código do brinco, identificador único do animal (chave primária)
        [Key] // Indica que esta propriedade é a chave primária da tabela
        [Column("CodigoBrinco")]  // Define o nome da coluna correspondente no banco de dados
        public String CodigoBrinco { get; set; }

        // Raça do animal
        [Column("Raca")]  // Define o nome da coluna correspondente no banco de dados
        public string? Raca { get; set; }

        // Peso do animal
        [Column("Peso")]  // Define o nome da coluna correspondente no banco de dados
        public double? Peso { get; set; }  // Peso é opcional, pois alguns registros podem não ter esse dado

        // Sexo do animal
        [Column("Sexo")]  // Define o nome da coluna correspondente no banco de dados
        public string? Sexo { get; set; }

        // Idade do animal em anos
        [Column("Idade")]  // Define o nome da coluna correspondente no banco de dados
        public int Idade { get; set; }
    }
}