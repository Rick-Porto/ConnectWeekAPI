using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IDesafioCategoriaRepository : IBaseRepository<DesafioCategoria>
{
    Task<IEnumerable<DesafioCategoria>> ObterDesafioCategoriaAsync(Guid idCategoria);
    Task<DesafioCategoria?> AssociarAsync(Guid idDesafio, Guid idCategoria);

    Task<DesafioCategoria?> DesassociarAsync(Guid idDesafio, Guid idCategoria);
    
    Task<bool> ExisteAssociacaoAsync(Guid idDesafio, Guid idCategoria);
}
