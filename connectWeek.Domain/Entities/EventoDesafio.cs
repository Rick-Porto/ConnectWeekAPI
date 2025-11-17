namespace connectWeek.Domain.Entities;

public class EventoDesafio
{
    public int Id { get; set; }
    public Guid EventoId { get; set; }
    public Guid DesafioId { get; set; }
    public int Ordem { get; set; }
    public bool Obrigatorio { get; set; }
    public DateTime Liberacao { get; set; }
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public Evento Evento { get; set; }
    public Desafio Desafio { get; set; }
}