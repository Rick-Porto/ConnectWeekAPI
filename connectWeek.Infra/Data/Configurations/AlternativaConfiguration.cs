using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class AlternativaConfiguration : IEntityTypeConfiguration<Alternativa>
{
    public void Configure(EntityTypeBuilder<Alternativa> builder)
    {
        builder.ToTable("ALTERNATIVA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PathImagem).HasMaxLength(500);

        builder
            .HasOne(x => x.Questao)
            .WithMany(q => q.Alternativas)
            .HasForeignKey(x => x.QuestaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
