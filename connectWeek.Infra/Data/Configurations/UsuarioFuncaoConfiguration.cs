using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using connectWeek.Domain.Entities;

namespace ConnectWeek.Infra.Data.Configurations;

public class UsuarioFuncaoConfiguration : IEntityTypeConfiguration<UsuarioFuncao>
{
    public void Configure(EntityTypeBuilder<UsuarioFuncao> builder)
    {
        builder.ToTable("USUARIO_FUNCAO");

        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Usuario)
            .WithMany(u => u.Funcoes)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Funcao)
            .WithMany()
            .HasForeignKey(x => x.FuncaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
