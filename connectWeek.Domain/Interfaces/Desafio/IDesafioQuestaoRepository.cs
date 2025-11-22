using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IDesafioQuestaoRepository : IBaseRepository<DesafioQuestao>
{
    Task<IEnumerable<Questao>> ObterQuestoesDesafioAsync(Guid idDesafio);
    Task<IEnumerable<DesafioQuestao>> ObterPorQuestaoAsync(Guid idQuestao);
    Task<DesafioQuestao?> AssociarAsync(Guid idDesafio, Guid idQuestao);
    Task<DesafioQuestao?> DesassociarAsync(Guid idDesafio, Guid idQuestao);
    Task<bool> ExisteAssociacaoAsync(Guid idDesafio, Guid idQuestao);
}
