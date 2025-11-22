namespace connectWeek.Domain.Entities;

public class Alternativa
{
    public Guid Id { get; set; }
    public Guid QuestaoId { get; set; }
    public string Texto { get; set; } = default!;
    public string? PathImagem { get; set; }
    public bool Correta { get; set; }
    public int Ordem { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    // RELACIONAMENTOS
    public Questao? Questao { get; set; }
}