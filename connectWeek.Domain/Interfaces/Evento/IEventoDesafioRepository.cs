using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IEventoDesafioRepository : IBaseRepository<EventoDesafio>
{
    Task<IEnumerable<EventoDesafio>> ObterDesafiosPorEventoAsync(Guid idEvento);
    Task<EventoDesafio?> AssociarAsync(Guid idDesafio, Guid idEvento);
    Task<EventoDesafio?> DesassociarAsync(Guid idDesafio, Guid idEvento);
    Task<bool> ExisteAssociacaoAsync(Guid idDesafio, Guid idEvento);
}
