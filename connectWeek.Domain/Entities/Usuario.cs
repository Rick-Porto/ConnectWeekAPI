namespace connectWeek.Domain.Entities;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string? PathImagem { get; set; }
    public bool EmailVerificado { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime UltimoAcesso { get; set; }
    public bool Ativo { get; set; }

    // RELACIONAMENTOS
    public ICollection<UsuarioAutenticacao>? Autenticacoes { get; set; }
    public ICollection<ConquistaUsuario>? Conquistas { get; set; }
    public ICollection<UsuarioFuncao>? Funcoes { get; set; }
    public ICollection<ExecucaoDesafio>? Execucoes { get; set; }
}