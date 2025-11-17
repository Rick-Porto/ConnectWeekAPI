using Microsoft.EntityFrameworkCore;
using connectWeek.Domain.Entities;

namespace connectWeek.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DBSets
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioAutenticacao> UsuariosAutenticacao { get; set; }
    public DbSet<Funcao> Funcoes { get; set; }
    public DbSet<UsuarioFuncao> UsuariosFuncoes { get; set; }

    public DbSet<Questao> Questoes { get; set; }
    public DbSet<Alternativa> Alternativas { get; set; }
    public DbSet<QuestaoCategoria> QuestoesCategorias { get; set; }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Desafio> Desafios { get; set; }
    public DbSet<DesafioQuestao> DesafiosQuestoes { get; set; }
    public DbSet<DesafioCategoria> DesafiosCategorias { get; set; }

    public DbSet<ExecucaoDesafio> ExecucoesDesafios { get; set; }
    public DbSet<RespostaQuestao> RespostasQuestoes { get; set; }

    public DbSet<Evento> Eventos { get; set; }
    public DbSet<EventoDesafio> EventosDesafios { get; set; }

    public DbSet<Conquista> Conquistas { get; set; }
    public DbSet<ConquistaUsuario> ConquistasUsuarios { get; set; }

    // CONFIGURAÇÕES
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

