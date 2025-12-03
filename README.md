# ConnectWeek API

ConnectWeek é uma plataforma para gerenciamento de desafios, usuários e eventos, construída em .NET, utilizando arquitetura de domínio com entidades bem definidas e relacionamento entre usuários, desafios e execuções.

## Sumário

- [Tecnologias](#tecnologias)  
- [Estrutura do Projeto](#estrutura-do-projeto)  
- [Modelagem de Dados](#modelagem-de-dados)  
- [Entidades Principais](#entidades-principais)  
- [Como Rodar](#como-rodar)  
- [Contribuição](#contribuição)  

## Tecnologias

- .NET 7  
- C#  
- Entity Framework Core  
- SQL Server (ou outro RDBMS compatível)  

## Estrutura do Projeto
```
connectWeekApi/
├─ connectWeek.Api/ # Camada de API (Controllers, Endpoints REST)
├─ connectWeek.App/ # Lógica de aplicação, DTOs, Regras de Negócio e Interfaces dos Serviços
├─ connectWeek.Domain/ # Entidades e Interfaces
│ ├─ Entities/
│ │ ├─ Usuario.cs
│ │ └─ Desafio.cs
│ └─ Interfaces/
├─ connectWeek.Infra/ # DbContext, Repositórios
```

## Modelagem de Dados

O banco de dados segue um modelo relacional baseado nas entidades do domínio. Abaixo estão os principais relacionamentos:

- **Usuario**
  - Pode ter várias autenticações (`UsuarioAutenticacao`)
  - Pode possuir conquistas (`ConquistaUsuario`)
  - Pode ter funções (`UsuarioFuncao`)
  - Pode criar desafios (`Desafio`)
  - Pode executar desafios (`ExecucaoDesafio`)

- **Desafio**
  - Possui questões (`DesafioQuestao`)
  - Pode pertencer a várias categorias (`DesafioCategoria`)
  - Pode estar associado a eventos (`EventoDesafio`)
  - Tem execuções realizadas por usuários (`ExecucaoDesafio`)
  - É criado por um usuário (`Usuario`)

- **Relacionamentos Principais**
  - 1:N entre `Usuario` e `Desafio` (criação)
  - N:N entre `Desafio` e `Usuario` via `ExecucaoDesafio`
  - 1:N entre `Desafio` e `DesafioQuestao`
  - N:N entre `Desafio` e `DesafioCategoria`
  
> Nota: O ERD completo inclui outras entidades como `Funcao`, `UsuarioAutenticacao`, `Questao` mas o foco principal para o módulo de desafios está em `Usuario` e `Desafio`.

---

## Diagrama ERD

```mermaid
erDiagram
	direction TB
	USUARIO_AUTENTICACAO {
		uuid Id PK  
		uuid UsuarioId FK  
		varchar50 Provider  
		nvarchar200 ProviderSub UK  
		nvarchar500 PasswordHash  
		datetime CriadoEm  
		datetime AtualizadoEm  
	}

	QUESTAO {
		uuid Id PK  
		nvarcharMAX Enunciado  
		nvarchar500 PathImagem  
		varchar50 TipoQuestao  
		decimal52 Peso  
		varchar20 Dificuldade  
		nvarcharMAX Explicacao  
		uuid CriadoPor FK  
		bit Publicado  
		int VezesUtilizada  
		datetime CriadoEm  
		datetime AtualizadoEm  
	}

	ALTERNATIVA {
		uuid Id PK  
		uuid QuestaoId FK  
		nvarcharMAX Texto  
		nvarchar500 PathImagem  
		bit Correta  
		int Ordem  
		datetime CriadoEm  
		datetime AtualizadoEm  
	}

	EVENTO_DESAFIO {
		uuid Id PK  
		uuid EventoId FK  
		uuid DesafioId FK  
		int Ordem  
		bit Obrigatorio  
		datetime Liberacao  
		datetime CriadoEm  
	}

	CONQUISTA_USUARIO {
		uuid Id PK  
		uuid UsuarioId FK  
		int ConquistaId FK  
		datetime ConquistadoEm  
		bit Visualizado  
	}

	NOTIFICACAO {
		uuid Id PK  
		uuid UsuarioId FK  
		nvarchar200 Titulo  
		nvarcharMAX Mensagem  
		varchar50 Tipo  
		nvarchar500 Link  
		bit Lida  
		datetime CriadoEm  
		datetime LidaEm  
	}

	DESAFIO {
		int Id PK  
		nvarchar200 Nome  
		nvarcharMAX Descricao  
		nvarchar500 PathImagem  
		datetime Inicio  
		datetime Fim  
		int QuantidadeQuestoes  
		decimal52 PercentualMinimo  
		int TempoMaximoMin  
		int MaxTentativas  
		bit MostrarResposta  
		bit EmbaralharQuestoes  
		varchar20 Dificuldade  
		uuid CriadoPor FK  
		bit Publicado  
		datetime CriadoEm  
		datetime AtualizadoEm  
	}

	DESAFIO_QUESTAO {
		uuid Id PK  
		uuid DesafioId FK  
		uuid QuestaoId FK  
		int Ordem  
	}

	DESAFIO_CATEGORIA {
		uuid Id PK  
		uuid DesafioId FK  
		int CategoriaId FK  
	}

	USUARIO {
		uuid Id PK  
		nvarchar200 Nome  
		nvarchar200 Email UK  
		nvarchar100 Username UK  
		nvarchar500 PathImagem  
		bit EmailVerificado  
		datetime CriadoEm  
		datetime UltimoAcesso  
		bit Ativo  
	}

	EVENTO {
		uuid Id PK  
		nvarchar200 Nome  
		nvarcharMAX Descricao  
		nvarchar500 PathImagem  
		datetime Inicio  
		datetime Fim  
		nvarchar500 Local  
		nvarchar500 LinkTransmissao  
		int CapacidadeMaxima  
		bit InscricaoAberta  
		uuid CriadoPor FK  
		bit Publicado  
		datetime CriadoEm  
		datetime AtualizadoEm  
	}

	CONQUISTA {
		int Id PK  
		nvarchar100 Nome UK  
		nvarchar500 Descricao  
		nvarcharMAX Criterio  
		int PontosBonus  
		datetime CriadoEm  
	}

	EXECUCAO_DESAFIO {
		uuid Id PK  
		uuid UsuarioId FK  
		uuid DesafioId FK  
		datetime IniciadoEm  
		datetime FinalizadoEm  
		decimal102 Pontuacao  
		decimal52 Percentual  
		bit Aprovado  
		int Tentativa  
		int TempoGasto  
		varchar20 Status  
		datetime CriadoEm  
	}

	RESPOSTA_QUESTAO {
		uuid Id PK  
		uuid ExecucaoId FK  
		uuid QuestaoId FK  
		uuid AlternativaId FK  
		bit Correta  
		decimal52 Pontuacao  
		int TempoResposta  
		datetime RespondidoEm  
	}

	FUNCAO {
		int Id PK  
		nvarchar50 Nome UK  
	}

	USUARIO_FUNCAO {
		uuid Id PK  
		uuid UsuarioId FK  
		int FuncaoId FK  
		datetime AtribuidoEm  
		uuid AtribuidoPor FK  
	}

	QUESTAO_CATEGORIA {
		uuid Id PK  
		uuid QuestaoId FK  
		int CategoriaId FK  
		datetime CriadoEm  
	}

	CATEGORIA {
		int Id PK  
		nvarchar100 Nome UK  
		datetime CriadoEm  
	}

	USUARIO||--o{USUARIO_AUTENTICACAO:"autenticacao"
	USUARIO||--o{USUARIO_FUNCAO:"papel"
	FUNCAO||--o{USUARIO_FUNCAO:"atribuido"
	USUARIO||--o{DESAFIO:"cria"
	USUARIO||--o{QUESTAO:"cria"
	USUARIO||--o{EVENTO:"cria"
	DESAFIO||--o{DESAFIO_QUESTAO:"contem"
	QUESTAO||--o{DESAFIO_QUESTAO:"associada"
	DESAFIO||--o{DESAFIO_CATEGORIA:"classificada"
	CATEGORIA||--o{DESAFIO_CATEGORIA:"aplica"
	QUESTAO||--|{ALTERNATIVA:"opcoes"
	QUESTAO||--o{QUESTAO_CATEGORIA:"taggeada"
	EVENTO||--o{EVENTO_DESAFIO:"inclui"
	DESAFIO||--o{EVENTO_DESAFIO:"ligado"
	USUARIO||--o{EXECUCAO_DESAFIO:"realiza"
	EXECUCAO_DESAFIO||--o{RESPOSTA_QUESTAO:"responde"
	DESAFIO||--o{EXECUCAO_DESAFIO:"avaliado"
	QUESTAO||--o{RESPOSTA_QUESTAO:"questao"
	ALTERNATIVA||--o{RESPOSTA_QUESTAO:"alternativa"
	USUARIO||--o{CONQUISTA_USUARIO:"ganha"
	CONQUISTA||--o{CONQUISTA_USUARIO:"atribuida"
	USUARIO||--o{NOTIFICACAO:"recebe"
	CATEGORIA}|--|{QUESTAO_CATEGORIA:""