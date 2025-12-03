using connectWeek.App.Dtos.Desafio;
using connectWeek.Domain.Entities;

namespace connectWeek.App.Interfaces;

public interface IDesafioService
{
    Task<Desafio> CriarDesafioAsync(CriaDesafioDto desafioDto, Guid idUsuario);
    Task<Desafio> AtualizarDesafioAsync(Guid idDesafio, AtualizaDesafioDto atualDesafioDto, Guid idUsuario);
    Task<IEnumerable<Desafio>> ObterDesafiosAsync();
    Task<Desafio?> ObterDesafioPorIdAsync(Guid id);
    Task<IEnumerable<Desafio>> ObterDesafioPorEventoAsync(Guid idEvento);
    Task RemoverDesafioAsync(Guid idDesafio);
}
