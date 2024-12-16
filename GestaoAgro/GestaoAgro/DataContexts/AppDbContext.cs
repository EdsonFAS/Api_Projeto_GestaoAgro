using GestaoAgro.Model;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<AnimalModel> Animal { get; set; }
        public DbSet<RebanhoModel> Rebanho { get; set; }
        public DbSet<PastagemModel> Pastagem { get; set; }
        public DbSet<AlimentacaoModel> Alimentacao { get; set; }
        public DbSet<RebanhoAlimentacaoModel> RebanhoAlimentacao { get; set; }
        public DbSet<SaudeModel> Saude { get; set; }
        public DbSet<ProducaoModel> Producao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PastagemModel>()
                .HasOne(p => p.Animal) // Relacionamento de navegação
                .WithMany()  // Caso um Animal tenha várias Pastagens
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            modelBuilder.Entity<RebanhoModel>()
                .HasOne(p => p.Animal) // Relacionamento de navegação
                .WithMany()
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            modelBuilder.Entity<ProducaoModel>()
                .HasOne(p => p.Animal) // Relacionamento de navegação
                .WithMany()  
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            modelBuilder.Entity<SaudeModel>()
                .HasOne(p => p.Animal) // Relacionamento de navegação
                .WithMany()
                .HasForeignKey(p => p.CodigoBrinco); // Chave estrangeira

            modelBuilder.Entity<RebanhoAlimentacaoModel>()
                .HasOne(p => p.Rebanho) // Relacionamento de navegação
                .WithMany()
                .HasForeignKey(p => p.IdRebanho); // Chave estrangeira

            modelBuilder.Entity<RebanhoAlimentacaoModel>()
                .HasOne(p => p.Alimentacao) // Relacionamento de navegação
                .WithMany()
                .HasForeignKey(p => p.IdAlimentacao); // Chave estrangeira



        }
    }
}
