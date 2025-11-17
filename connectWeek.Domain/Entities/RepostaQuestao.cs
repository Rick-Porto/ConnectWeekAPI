namespace connectWeek.Domain.Entities;

public class RespostaQuestao
{
    public int Id { get; set; }
    public Guid ExecucaoId { get; set; }
    public Guid QuestaoId { get; set; }
    public Guid AlternativaId { get; set; }
    public bool Correta { get; set; }
    public decimal Pontuacao { get; set; }
    public int TempoResposta { get; set; }
    public DateTime RespondidoEm { get; set; }

    // RELACIONAMENTOS
    public ExecucaoDesafio Execucao { get; set; }
    public Questao Questao { get; set; }
    public Alternativa Alternativa { get; set; }
}