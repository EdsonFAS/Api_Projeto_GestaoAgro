using Microsoft.EntityFrameworkCore;
using APi_aula06.Model;

namespace APi_aula06.DataContexts

{
    public class AppDContexts : DbContext

    {
        public AppDContexts(DbContextOptions<AppDContexts> options) : base(options) { }

        public DbSet<ServidorModel> Servidores { get; set; }
    }
}
