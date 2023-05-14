using Microsoft.EntityFrameworkCore;
using ProjetoFromLuiz.Models;

namespace ProjetoFromLuiz.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PessoaModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Idade).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Peso).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Altura).IsRequired().HasMaxLength(255);
            
        }
    }
}
