using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities;

namespace ConnectWeek.Infra.Data.Configurations;

public class QuestaoConfiguration : IEntityTypeConfiguration<Questao>
{
    public void Configure(EntityTypeBuilder<Questao> builder)
    {
        builder.ToTable("QUESTAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PathImagem).HasMaxLength(500);
        builder.Property(x => x.TipoQuestao).HasMaxLength(50);
        builder.Property(x => x.Dificuldade).HasMaxLength(20);

        // Campo Guid simples
        builder.Property(x => x.CriadoPor)
            .IsRequired();
    }
}
