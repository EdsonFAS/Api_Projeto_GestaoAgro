﻿using GestaoAgro.Model;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.DataContexts
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options) { }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<AnimalModel> Animal { get; set; }
        public DbSet<RebanhoModel> Rebanho { get; set; }
        public DbSet<PastagemModel> Pastagem { get; set; }
        public DbSet<AlimentacaoModel> Alimentacao { get; set; }
        public DbSet<RebanhoAlimentacaoModel> RebanhoAlimentacao { get; set; }
        public DbSet<SaudeModel> Saude { get; set; }
        public DbSet<ProducaoModel> Producao { get; set; }
    }
}
