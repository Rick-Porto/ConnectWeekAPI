using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;
public interface IExecucaoDesafioRepository : IBaseRepository<ExecucaoDesafio>
{
    Task<ExecucaoDesafio?> ObterPorUsuarioDesafioAsync(Guid idUsuario, Guid idDesafio);
    Task<IEnumerable<ExecucaoDesafio>> ObterPorUsuarioIdAsync(Guid idUsuario);
    Task<IEnumerable<ExecucaoDesafio>> ObterPorDesafioIdAsync(Guid idDesafio);
    Task<IEnumerable<ExecucaoDesafio>> ObterPorStatusAsync(string status);
    Task<int> ObterTentativasAsync(Guid idUsuario, Guid idDesafio);
}