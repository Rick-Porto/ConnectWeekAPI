using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class DesafioQuestaoConfiguration : IEntityTypeConfiguration<DesafioQuestao>
{
    public void Configure(EntityTypeBuilder<DesafioQuestao> builder)
    {
        builder.ToTable("DESAFIO_QUESTAO");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Desafio)
            .WithMany(q => q.Questoes)
            .HasForeignKey(x => x.DesafioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Questao)
            .WithMany(q => q.DesafioQuestoes)
            .HasForeignKey(x => x.QuestaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
