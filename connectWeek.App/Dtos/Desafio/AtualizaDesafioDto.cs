namespace connectWeek.App.Dtos.Desafio;

public class AtualizaDesafioDto
{
    public string Nome { get; set; } = default!;
    public string? Descricao { get; set; }
    public string? PathImagem { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public int QuantidadeQuestoes { get; set; }
    public decimal PercentualMinimo { get; set; }
    public int TempoMaximoMin { get; set; }
    public int MaxTentativas { get; set; }
    public bool MostrarResposta { get; set; }
    public bool EmbaralharQuestoes { get; set; }
    public string? Dificuldade { get; set; }
    public bool Publicado { get; set; }
}
