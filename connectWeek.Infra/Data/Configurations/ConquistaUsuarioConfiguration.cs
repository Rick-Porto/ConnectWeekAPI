using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class ConquistaUsuarioConfiguration : IEntityTypeConfiguration<ConquistaUsuario>
{
    public void Configure(EntityTypeBuilder<ConquistaUsuario> builder)
    {
        builder.ToTable("CONQUISTA_USUARIO");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Usuario)
            .WithMany(u => u.Conquistas)   // AGORA aponta pra coleção real
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Conquista)
            .WithMany(c => c.Usuarios)     // AGORA aponta pra coleção real
            .HasForeignKey(x => x.ConquistaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
