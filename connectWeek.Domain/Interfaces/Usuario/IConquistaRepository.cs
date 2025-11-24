using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IConquistaRepository : IBaseRepository<Conquista>
{
    Task<IEnumerable<Conquista>> ObterPorUsuarioIdAsync(Guid usuarioId);

}