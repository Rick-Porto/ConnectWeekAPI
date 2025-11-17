using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("CATEGORIA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        builder.HasIndex(x => x.Nome).IsUnique();
    }
}
