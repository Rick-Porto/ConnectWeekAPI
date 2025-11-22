using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces;

public interface IRespostaQuestaoRepository : IBaseRepository<RespostaQuestao>
{
    Task<IEnumerable<RespostaQuestao>> ObterPorExecucaoIdAsync(Guid idExecucao);
    Task<IEnumerable<RespostaQuestao>> ObterPorQuestaoIdAsync(Guid idQuestao);
    // Task<RespostaQuestao?> ObterPorExecucaoEQuestaoAsync(Guid idExecucao, Guid idQuestao);
    Task<decimal> ObterPontuacaoAsync(Guid idExecucao);
}