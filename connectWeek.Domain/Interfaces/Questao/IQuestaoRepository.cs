using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IQuestaoRepository : IBaseRepository<Questao>
{
    Task<IEnumerable<Questao>> ObterPorDificuldadeAsync(string dificuldade);
    Task<IEnumerable<Questao>> ObterPorTipoAsync(string tipo);
    Task<IEnumerable<Questao>> ObterPublicadasAsync();
    Task<IEnumerable<Questao>> ObterPorUsuarioAsync(Guid usuarioId);
    Task<Questao?> ObterComAlternativasAsync(Guid id);
    Task<Questao?> ObterComCategoriasAsync(Guid id);
    Task IncrementarVezesUtilizadaAsync(Guid id);
}