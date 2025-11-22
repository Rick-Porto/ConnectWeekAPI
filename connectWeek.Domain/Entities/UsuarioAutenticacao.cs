namespace connectWeek.Domain.Entities;

public class UsuarioAutenticacao
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string? Provider { get; set; }
    public string? ProviderSub { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    // RELACIONAMENTOS
    public Usuario? Usuario { get; set; }
}