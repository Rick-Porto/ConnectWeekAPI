using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.ToTable("EVENTO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
        builder.Property(x => x.PathImagem).HasMaxLength(500);
        builder.Property(x => x.Local).HasMaxLength(500);
        builder.Property(x => x.LinkTransmissao).HasMaxLength(500);

        builder.Property(x => x.CriadoPor)
            .IsRequired();
    }
}
