using Microsoft.EntityFrameworkCore;
using GestaoAgro.Model;
using System;
using GestaoAgro.Dtos;
namespace GestaoAgro.DataContexts
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options) { }
        public DbSet<AnimalModel> Animais { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
