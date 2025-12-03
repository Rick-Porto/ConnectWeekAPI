using System.ComponentModel.DataAnnotations.Schema;

namespace connectWeek.Domain.Entities;

public class Desafio
{
    public Guid Id { get; set; }
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
    public Guid CriadoPor { get; set; }
    public bool Publicado { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }

    // RELACIONAMENTOS
    [ForeignKey(nameof(CriadoPor))]
    public Usuario? Usuario { get; set; }
    public ICollection<DesafioQuestao>? Questoes { get; set; }
    public ICollection<DesafioCategoria>? Categorias { get; set; }
    public ICollection<EventoDesafio>? Eventos { get; set; }
    public ICollection<ExecucaoDesafio>? Execucoes { get; set; }
}