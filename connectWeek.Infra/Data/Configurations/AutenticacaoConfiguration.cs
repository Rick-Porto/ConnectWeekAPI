using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities; // ajuste conforme namespace

namespace ConnectWeek.Infra.Data.Configurations;

public class UsuarioAutenticacaoConfiguration : IEntityTypeConfiguration<UsuarioAutenticacao>
{
    public void Configure(EntityTypeBuilder<UsuarioAutenticacao> builder)
    {
        builder.ToTable("USUARIO_AUTENTICACAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Provider).HasMaxLength(50);
        builder.Property(x => x.ProviderSub).HasMaxLength(200).IsRequired();
        builder.Property(x => x.PasswordHash).HasMaxLength(500);

        builder.HasIndex(x => x.ProviderSub).IsUnique();

        builder
            .HasOne(x => x.Usuario)
            .WithMany(u => u.Autenticacoes)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
