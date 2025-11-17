namespace connectWeek.Domain.Entities;

public class DesafioCategoria
{
    public Guid Id { get; set; }
    public Guid DesafioId { get; set; }
    public int CategoriaId { get; set; }

    // RELACIONAMENTOS
    public Desafio Desafio { get; set; }
    public Categoria Categoria { get; set; }
}