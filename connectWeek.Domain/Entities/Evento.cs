namespace connectWeek.Domain.Entities;

public class Evento
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string? Descricao { get; set; }
    public string? PathImagem { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public string? Local { get; set; }
    public string? LinkTransmissao { get; set; }
    public int CapacidadeMaxima { get; set; }
    public bool InscricaoAberta { get; set; }
    public Guid CriadoPor { get; set; }
    public bool Publicado { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    // RELACIONAMENTOS
    public Usuario? Usuario { get; set; }
    public ICollection<EventoDesafio>? Desafios { get; set; }
}