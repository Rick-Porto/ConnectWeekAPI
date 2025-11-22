using connectWeek.Domain.Entities;
using connectWeek.Domain.Interfaces.Base;

namespace connectWeek.Domain.Interfaces.Questao;

public interface IQuestaoRepository : IBaseRepository<Entities.Questao>
{
    Task<IEnumerable<Entities.Questao>> ObterPorDificuldadeAsync(string dificuldade);
    Task<IEnumerable<Entities.Questao>> ObterPorTipoAsync(string tipo);
    Task<IEnumerable<Entities.Questao>> ObterPublicadasAsync();
    Task<IEnumerable<Entities.Questao>> ObterPorUsuarioAsync(Guid usuarioId);
    Task<Entities.Questao?> ObterComAlternativasAsync(Guid id);
    Task<Entities.Questao?> ObterComCategoriasAsync(Guid id);
    Task IncrementarVezesUtilizadaAsync(Guid id);
}