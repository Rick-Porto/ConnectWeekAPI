namespace connectWeek.Domain.Entities;

public class Questao
{
    public Guid Id { get; set; }
    public string Enunciado { get; set; } = default!;
    public string? PathImagem { get; set; }
    public string TipoQuestao { get; set; } = default!;
    public decimal Peso { get; set; }
    public string Dificuldade { get; set; } = default!;
    public string Explicacao { get; set; } = default!;
    public Guid CriadoPor { get; set; }
    public bool Publicado { get; set; }
    public int VezesUtilizada { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    // RELACIONAMENTOS
    public Usuario? Usuario { get; set; }
    public ICollection<Alternativa>? Alternativas { get; set; }
    public ICollection<QuestaoCategoria>? Categorias { get; set; }
    public ICollection<DesafioQuestao>? DesafioQuestoes { get; set; }
    public ICollection<RespostaQuestao>? Respostas { get; set; }
}