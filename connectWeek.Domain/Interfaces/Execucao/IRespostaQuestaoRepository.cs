using connectWeek.Domain.Entities;

namespace connectWeek.Domain.Interfaces.Execucao;

public interface IRespostaQuestaoRepository : IBaseRepository<RespostaQuestao>
{
    Task<IEnumerable<RespostaQuestao>> ObterPorExecucaoIdAsync(Guid idExecucao);
    Task<IEnumerable<RespostaQuestao>> ObterPorQuestaoIdAsync(Guid idQuestao);
    Task<RespostaQuestao?> ObterPorAlternativaIdAsync(Guid idAlternativa);
    Task<decimal> ObterPontuacaoTotalAsync(Guid idExecucao);
}