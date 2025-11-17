namespace connectWeek.Domain.Entities;

public class UsuarioFuncao
{
    public int Id { get; set; }
    public Guid UsuarioId { get; set; }
    public int FuncaoId { get; set; }
    public DateTime AtribuidoEm { get; set; }
    public Guid AtribuidoPor { get; set; }

    // RELACIONAMENTOS
    public Usuario Usuario { get; set; }
    public Funcao Funcao { get; set; }
}