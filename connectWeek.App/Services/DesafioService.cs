using connectWeek.App.Dtos.Desafio;
using connectWeek.Domain.Entities;
using connectWeek.Domain.Interfaces;
using connectWeek.App.Interfaces;

namespace connectWeek.App.Services;

public class DesafioService : IDesafioService
{
    private readonly IDesafioRepository _repository;

    public DesafioService(IDesafioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Cria um novo desafio a partir do DTO
    /// </summary>
    public async Task<Desafio> CriarDesafioAsync(CriaDesafioDto desafioDto, Guid idUsuario)
    {
        // var validacao = ValidarCriacaoDesafio(dto);
        // if (validacao != ValidationResult.Success)
        //     throw new ArgumentException(validacao.ErrorMessage);

        var desafio = new Desafio
        {
            Id = Guid.NewGuid(),
            Nome = desafioDto.Nome,
            Descricao = desafioDto.Descricao,
            PathImagem = desafioDto.PathImagem,
            Inicio = desafioDto.Inicio,
            Fim = desafioDto.Fim,
            QuantidadeQuestoes = desafioDto.QuantidadeQuestoes,
            PercentualMinimo = desafioDto.PercentualMinimo,
            TempoMaximoMin = desafioDto.TempoMaximoMin,
            MaxTentativas = desafioDto.MaxTentativas,
            MostrarResposta = desafioDto.MostrarResposta,
            EmbaralharQuestoes = desafioDto.EmbaralharQuestoes,
            Dificuldade = desafioDto.Dificuldade,
            Publicado = desafioDto.Publicado,
            CriadoPor = idUsuario,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow
        };

        await _repository.AdicionarAsync(desafio);
        return desafio;
    }

    /// <summary>
    /// Atualiza um desafio existente
    /// </summary>
    public async Task<Desafio> AtualizarDesafioAsync(Guid idDesafio, AtualizaDesafioDto atualDesafioDto, Guid idUsuario)
    {
        // var validacao = ValidarAtualizacaoDesafio(dto);
        // if (validacao != ValidationResult.Success)
        //     throw new ArgumentException(validacao.ErrorMessage);

        var desafio = await _repository.ObterPorIdAsync(idDesafio);
        if (desafio == null)
            throw new KeyNotFoundException($"Desafio com ID {idDesafio} não encontrado");

        desafio.Nome = atualDesafioDto.Nome;
        desafio.Descricao = atualDesafioDto.Descricao;
        desafio.PathImagem = atualDesafioDto.PathImagem;
        desafio.Inicio = atualDesafioDto.Inicio;
        desafio.Fim = atualDesafioDto.Fim;
        desafio.QuantidadeQuestoes = atualDesafioDto.QuantidadeQuestoes;
        desafio.PercentualMinimo = atualDesafioDto.PercentualMinimo;
        desafio.TempoMaximoMin = atualDesafioDto.TempoMaximoMin;
        desafio.MaxTentativas = atualDesafioDto.MaxTentativas;
        desafio.MostrarResposta = atualDesafioDto.MostrarResposta;
        desafio.EmbaralharQuestoes = atualDesafioDto.EmbaralharQuestoes;
        desafio.Dificuldade = atualDesafioDto.Dificuldade;
        desafio.Publicado = atualDesafioDto.Publicado;
        desafio.AtualizadoEm = DateTime.UtcNow;

        await _repository.AtualizarAsync(desafio);
        return desafio;
    }

    /// <summary>
    /// Obtém todos os desafios
    /// </summary>
    public async Task<IEnumerable<Desafio>> ObterDesafiosAsync()
    {
        return await _repository.ObterTodosAsync();
    }


    /// <summary>
    /// Obtém um desafio por ID
    /// </summary>
    public async Task<Desafio?> ObterDesafioPorIdAsync(Guid idDesafio)
    {
        return await _repository.ObterPorIdAsync(idDesafio);
    }

    /// <summary>
    /// Obtém desafios por evento
    /// </summary>
    public async Task<IEnumerable<Desafio>> ObterDesafioPorEventoAsync(Guid idEvento)
    {
        return await _repository.ObterPorEventoAsync(idEvento);
    }

    /// <summary>
    /// Remove um desafio
    /// </summary>
    public async Task RemoverDesafioAsync(Guid idDesafio)
    {
        var desafio = await _repository.ObterPorIdAsync(idDesafio);
        if (desafio == null)
            throw new KeyNotFoundException($"Desafio com ID {idDesafio} não encontrado");
        await _repository.RemoverAsync(idDesafio);
    }

}

