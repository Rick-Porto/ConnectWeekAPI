using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IDesafioRepository : IBaseRepository<Desafio>
{
    Task<IEnumerable<Desafio>> ObterPorEventoAsync(Guid idEvento);
}






