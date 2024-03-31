using CadastroLivros.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroLivros.Infrastructure.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                .IsRequired()
                .HasColumnType("varchar(250)");

            

            builder.ToTable("Livros");
        }
    }
}
