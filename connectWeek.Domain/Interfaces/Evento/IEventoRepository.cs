using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces.Evento
{
    public interface IEventoRepository : IBaseRepository<Evento>
    {
        Task<IEnumerable<Evento>> ObterPorDataAsync(DateTime data);
        Task<IEnumerable<Evento>> ObterEventosAtivosAsync();
    }
}