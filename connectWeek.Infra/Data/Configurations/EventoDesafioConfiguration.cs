using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class EventoDesafioConfiguration : IEntityTypeConfiguration<EventoDesafio>
{
    public void Configure(EntityTypeBuilder<EventoDesafio> builder)
    {
        builder.ToTable("EVENTO_DESAFIO");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Evento)
            .WithMany(e => e.Desafios)
            .HasForeignKey(x => x.EventoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Desafio)
            .WithMany()
            .HasForeignKey(x => x.DesafioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
