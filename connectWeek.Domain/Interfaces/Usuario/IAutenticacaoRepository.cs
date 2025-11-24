using connectWeek.Domain.Entities;
namespace connectWeek.Domain.Interfaces;

public interface IAutenticacaoRepository : IBaseRepository<UsuarioAutenticacao>
{
    Task<UsuarioAutenticacao?> ObterPorUsuarioIdAsync(Guid idUsuario);
    Task<UsuarioAutenticacao?> ObterPorProviderAsync(string provider, string providerSub);
    Task<bool> ExisteAsync(Guid id);
}
