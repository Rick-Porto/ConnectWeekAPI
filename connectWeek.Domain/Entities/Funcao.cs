namespace connectWeek.Domain.Entities;

public class Funcao
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public ICollection<UsuarioFuncao>? Usuarios { get; set; }
}