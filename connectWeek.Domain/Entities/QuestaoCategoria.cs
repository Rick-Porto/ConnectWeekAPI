namespace connectWeek.Domain.Entities;

public class QuestaoCategoria
{
    public int Id { get; set; }
    public Guid QuestaoId { get; set; }
    public int CategoriaId { get; set; }
    public DateTime CriadoEm { get; set; }

    // RELACIONAMENTOS
    public Questao Questao { get; set; }
    public Categoria Categoria { get; set; }
}