namespace connectWeek.Domain.Entities;

public class DesafioQuestao
{
    public int Id { get; set; }
    public Guid DesafioId { get; set; }
    public Guid QuestaoId { get; set; }
    public int Ordem { get; set; }
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public Desafio Desafio { get; set; }
    public Questao Questao { get; set; }
}