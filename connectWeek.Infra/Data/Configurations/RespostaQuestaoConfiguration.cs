using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class RespostaQuestaoConfiguration : IEntityTypeConfiguration<RespostaQuestao>
{
    public void Configure(EntityTypeBuilder<RespostaQuestao> builder)
    {
        builder.ToTable("RESPOSTA_QUESTAO");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Execucao)
            .WithMany(e => e.Respostas)
            .HasForeignKey(x => x.ExecucaoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Questao)
            .WithMany()
            .HasForeignKey(x => x.QuestaoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Alternativa)
            .WithMany()
            .HasForeignKey(x => x.AlternativaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
