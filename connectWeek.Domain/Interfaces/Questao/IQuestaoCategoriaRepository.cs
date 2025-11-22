using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IQuestaoCategoriaRepository : IBaseRepository<QuestaoCategoria>
{
    
    Task<QuestaoCategoria?> ObterPorNomeAsync(string nome);
    Task<IEnumerable<QuestaoCategoria>> ObterPorListaNomesAsync(IEnumerable<string> nomes);
    Task<QuestaoCategoria?> AssociarAsync(Guid idCategoria, Guid idQuestao);
    Task<DesafioQuestao?> DesassociarAsync(Guid idCategoria, Guid idQuestao);
    Task<bool> ExisteAssociacaoAsync(Guid idCategoria, Guid idQuestao);
}