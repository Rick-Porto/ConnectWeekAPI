namespace connectWeek.Domain.Entities;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PathImagem { get; set; }
    public bool EmailVerificado { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime UltimoAcesso { get; set; }
    public bool Ativo { get; set; }

    // RELACIONAMENTOS
    public ICollection<UsuarioAutenticacao> Autenticacoes { get; set; }
    public ICollection<ConquistaUsuario> Conquistas { get; set; }
    public ICollection<Notificacao> Notificacoes { get; set; }
    public ICollection<UsuarioFuncao> Funcoes { get; set; }
    public ICollection<ExecucaoDesafio> Execucoes { get; set; }
}