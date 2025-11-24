using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IConquistaRepository : IBaseRepository<ConquistaUsuario>
{
    Task<IEnumerable<ConquistaUsuario>> ObterPorUsuarioIdAsync(Guid usuarioId);
    Task<ConquistaUsuario?> AssociarAsync(Guid idUsuario, Guid idConquista);
    Task<ConquistaUsuario?> DesassociarAsync(Guid idUsuario, Guid idConquista);
    Task<bool> ExisteAssociacaoAsync(Guid idUsuario, Guid idConquista);
    Task<bool> ExisteAsync(Guid idUsuario, Guid idConquista);

} 