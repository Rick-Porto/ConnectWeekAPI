using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities;

namespace connectWeek.Infra.Data.Configurations;

public class DesafioConfiguration : IEntityTypeConfiguration<Desafio>
{
    public void Configure(EntityTypeBuilder<Desafio> builder)
    {
        builder.ToTable("DESAFIO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.PathImagem)
            .HasMaxLength(500);

        builder.Property(x => x.Dificuldade)
            .HasMaxLength(20);

        builder.Property(x => x.CriadoPor)
            .IsRequired();

        // FK correta
        builder
            .HasOne(x => x.Usuario)
            .WithMany(u => u.DesafiosCriados)
            .HasForeignKey(x => x.CriadoPor)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
