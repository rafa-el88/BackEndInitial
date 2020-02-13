using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Events;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Application.Mapper
{
    public class DomainToViewModelMap : Profile
    {
        public DomainToViewModelMap()
        {
            CreateMap<Administrador, AdministradorViewModel>();
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<Colecao, ColecaoViewModel>();
            CreateMap<DestinatarioMensagem, DestinatarioMensagemViewModel>();
            CreateMap<Disciplina, DisciplinaViewModel>();
            CreateMap<Escola, EscolaViewModel>();
            CreateMap<Mensagem, MensagemViewModel>();
            CreateMap<NivelEnsino, NivelEnsinoViewModel>();
            CreateMap<Periodo, PeriodoViewModel>();
            CreateMap<PeriodoLetivoConfiguracao, PeriodoLetivoConfiguracaoViewModel>();
            CreateMap<PeriodoLetivoTipo, PeriodoLetivoTipoViewModel>();
            CreateMap<Professor, ProfessorViewModel>();
            CreateMap<Responsavel, ResponsavelViewModel>();
            CreateMap<Serie, SerieViewModel>();
            CreateMap<Turma, TurmaViewModel>();
            CreateMap<TurmaDisciplinaProfessor, TurmaDisciplinaProfessorViewModel>();
            CreateMap<ConvidadosEvento, ConvidadosEventoViewModel>();

            /* Mapeamento para criação dos eventos no Handles com List. Ex: handlerCreateEscolas */
            CreateMap<CommandResult, EventsResult>();
        }
    }
}
