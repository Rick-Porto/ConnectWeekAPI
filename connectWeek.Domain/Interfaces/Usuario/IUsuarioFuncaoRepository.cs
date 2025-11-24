using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IUsuarioFuncaoRepository : IBaseRepository<UsuarioFuncao>
{
    Task<IEnumerable<UsuarioFuncao>> ObterPorUsuarioIdAsync(Guid idUsuario);
    Task<UsuarioFuncao?> AssociarAsync(Guid idUsuario, Guid idFuncao);
    Task<UsuarioFuncao?> DesassociarAsync(Guid idUsuario, Guid idFuncao);
    Task<bool> ExisteAssociacaoAsync(Guid idUsuario, Guid idFuncao);

} 