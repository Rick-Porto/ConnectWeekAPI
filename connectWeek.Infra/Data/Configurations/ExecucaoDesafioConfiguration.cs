using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class ExecucaoDesafioConfiguration : IEntityTypeConfiguration<ExecucaoDesafio>
{
    public void Configure(EntityTypeBuilder<ExecucaoDesafio> builder)
    {
        builder.ToTable("EXECUCAO_DESAFIO");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Usuario)
            .WithMany()
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Desafio)
            .WithMany()
            .HasForeignKey(x => x.DesafioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
