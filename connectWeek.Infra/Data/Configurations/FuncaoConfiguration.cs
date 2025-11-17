using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class FuncaoConfiguration : IEntityTypeConfiguration<Funcao>
{
    public void Configure(EntityTypeBuilder<Funcao> builder)
    {
        builder.ToTable("FUNCAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
        builder.HasIndex(x => x.Nome).IsUnique();
    }
}
