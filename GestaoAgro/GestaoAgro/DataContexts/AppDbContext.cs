using GestaoAgro.Model;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.DataContexts
{
    // Contexto do banco de dados para a aplicação, herdando DbContext
    public class AppDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração do banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definindo as tabelas que correspondem aos modelos no banco de dados
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<AnimalModel> Animal { get; set; }
        public DbSet<RebanhoModel> Rebanho { get; set; }
        public DbSet<PastagemModel> Pastagem { get; set; }
        public DbSet<AlimentacaoModel> Alimentacao { get; set; }
        public DbSet<RebanhoAlimentacaoModel> RebanhoAlimentacao { get; set; }
        public DbSet<SaudeModel> Saude { get; set; }
        public DbSet<ProducaoModel> Producao { get; set; }

        // Configurando os relacionamentos entre as tabelas (entidades)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento entre Pastagem e Animal
            modelBuilder.Entity<PastagemModel>()
                .HasOne(p => p.Animal) // Um Pastagem tem um Animal
                .WithMany() // Um Animal pode ter várias Pastagens
                .HasForeignKey(p => p.CodigoBrinco); // Definindo a chave estrangeira

            // Relacionamento entre Rebanho e Animal
            modelBuilder.Entity<RebanhoModel>()
                .HasOne(p => p.Animal) // Um Rebanho tem um Animal
                .WithMany() // Um Animal pode estar em vários Rebanhos
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            // Relacionamento entre Producao e Animal
            modelBuilder.Entity<ProducaoModel>()
                .HasOne(p => p.Animal) // Uma Producao pertence a um Animal
                .WithMany() // Um Animal pode ter várias Produções
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            // Relacionamento entre Saude e Animal
            modelBuilder.Entity<SaudeModel>()
                .HasOne(p => p.Animal) // Uma Saude pertence a um Animal
                .WithMany() // Um Animal pode ter vários registros de Saúde
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            // Relacionamento entre RebanhoAlimentacao e Rebanho
            modelBuilder.Entity<RebanhoAlimentacaoModel>()
                .HasOne(p => p.Rebanho) // Um RebanhoAlimentacao pertence a um Rebanho
                .WithMany() // Um Rebanho pode ter várias Alimentações
                .HasForeignKey(p => p.IdRebanho); // Chave estrangeira

            // Relacionamento entre RebanhoAlimentacao e Alimentacao
            modelBuilder.Entity<RebanhoAlimentacaoModel>()
                .HasOne(p => p.Alimentacao) // Um RebanhoAlimentacao pertence a uma Alimentação
                .WithMany() // Uma Alimentação pode ser associada a vários Rebanhos
                .HasForeignKey(p => p.IdAlimentacao); // Chave estrangeira
        }
    }
}