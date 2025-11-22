namespace connectWeek.Domain.Entities;

public class Categoria
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public ICollection<QuestaoCategoria>? Questoes { get; set; }
    public ICollection<DesafioCategoria>? Desafios { get; set; }
}