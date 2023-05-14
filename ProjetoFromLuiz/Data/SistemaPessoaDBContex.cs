using Microsoft.EntityFrameworkCore;
using ProjetoFromLuiz.Data.Map;
using ProjetoFromLuiz.Models;

namespace ProjetoFromLuiz.Data
{
    public class SistemaPessoaDBContex : DbContext
    {
        public SistemaPessoaDBContex(DbContextOptions<SistemaPessoaDBContex> options)
            : base(options) 
        { 
        }

        public DbSet<PessoaModel> PessoaSistema { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
