namespace connectWeek.Domain.Entities;

public class ExecucaoDesafio
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid DesafioId { get; set; }
    public DateTime IniciadoEm { get; set; }
    public DateTime FinalizadoEm { get; set; }
    public decimal Pontuacao { get; set; }
    public decimal Percentual { get; set; }
    public bool Aprovado { get; set; }
    public int Tentativa { get; set; }
    public int TempoGasto { get; set; }
    public string Status { get; set; } = default!;
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public Usuario? Usuario { get; set; }
    public Desafio? Desafio { get; set; }
    public ICollection<RespostaQuestao>? Respostas { get; set; }
}