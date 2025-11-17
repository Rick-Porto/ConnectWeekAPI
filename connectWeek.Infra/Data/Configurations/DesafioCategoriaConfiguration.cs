using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class DesafioCategoriaConfiguration : IEntityTypeConfiguration<DesafioCategoria>
{
    public void Configure(EntityTypeBuilder<DesafioCategoria> builder)
    {
        builder.ToTable("DESAFIO_CATEGORIA");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Desafio)
            .WithMany(d => d.Categorias)
            .HasForeignKey(x => x.DesafioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Categoria)
            .WithMany(c => c.Desafios)
            .HasForeignKey(x => x.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
