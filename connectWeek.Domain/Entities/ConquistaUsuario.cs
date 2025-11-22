namespace connectWeek.Domain.Entities;

public class ConquistaUsuario
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid ConquistaId { get; set; }
    public DateTime ConquistadoEm { get; set; }
    public bool Visualizado { get; set; }

    // RELACIONAMENTOS
    public Usuario? Usuario { get; set; }
    public Conquista? Conquista { get; set; }
}