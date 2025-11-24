using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<bool> ExistePorEmailAsync(string email);
    Task<IEnumerable<Usuario>> EmailVerificadoAsync(Guid idUsuario);
    Task<bool> ExistePorCpfAsync(string cpf);
} 