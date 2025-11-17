using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class QuestaoCategoriaConfiguration : IEntityTypeConfiguration<QuestaoCategoria>
{
    public void Configure(EntityTypeBuilder<QuestaoCategoria> builder)
    {
        builder.ToTable("QUESTAO_CATEGORIA");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Questao)
            .WithMany(q => q.Categorias)
            .HasForeignKey(x => x.QuestaoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Categoria)
            .WithMany(c => c.Questoes)
            .HasForeignKey(x => x.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
