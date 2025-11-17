namespace connectWeek.Domain.Entities;

public class Conquista
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Criterio { get; set; }
    public int PontosBonus { get; set; }
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public ICollection<ConquistaUsuario> Usuarios { get; set; }
}