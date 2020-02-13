using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.Events;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Application.Mapper
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap()
        {
            //Convidado Evento
            CreateMap<ConvidadosEventoViewModel, ConvidadosEvento>();

            //Administrador
            CreateMap<AdministradorViewModel, Administrador>();
            CreateMap<CreateAdministradorCommand, Administrador>();
            CreateMap<UpdateAdministradorCommand, Administrador>();

            //Aluno
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<CreateAlunoCommand, Aluno>();
            CreateMap<UpdateAlunoCommand, Aluno>();

            //Coleção
            CreateMap<ColecaoViewModel, Colecao>();
            CreateMap<CreateColecaoCommand, Colecao>();
            CreateMap<UpdateColecaoCommand, Colecao>();

            //Destinatario mensagem
            CreateMap<DestinatarioMensagemViewModel, DestinatarioMensagem>();
            CreateMap<CreateDestinatarioMensagemCommand, DestinatarioMensagem>();
            CreateMap<UpdateDestinatarioMensagemCommand, DestinatarioMensagem>();
            
            //Disciplina
            CreateMap<DisciplinaViewModel, Disciplina>();

            //Escola
            CreateMap<EscolaViewModel, Escola>();

            //Mensagem
            CreateMap<Mensagem, MensagemViewModel>();
            CreateMap<CreateMensagemCommand, Mensagem>();
            CreateMap<UpdateMensagemCommand, Mensagem>();

            //Nivel ensino
            CreateMap<NivelEnsinoViewModel, NivelEnsino>();

            //Periodo
            CreateMap<PeriodoViewModel, Periodo>();
            CreateMap<CreatePeriodoCommand, Periodo>();
            CreateMap<UpdatePeriodoCommand, Periodo>();

            //Periodo letivo configuração
            CreateMap<PeriodoLetivoConfiguracaoViewModel, PeriodoLetivoConfiguracao>();
            CreateMap<CreatePeriodoLetivoConfiguracaoCommand, PeriodoLetivoConfiguracao>();
            CreateMap<UpdatePeriodoLetivoConfiguracaoCommand, PeriodoLetivoConfiguracao>();

            //Periodo letivo tipo
            CreateMap<PeriodoLetivoTipoViewModel, PeriodoLetivoTipo>();
            CreateMap<CreatePeriodoLetivoTipoCommand, PeriodoLetivoTipo>();
            CreateMap<UpdatePeriodoLetivoTipoCommand, PeriodoLetivoTipo>();

            //Professor
            CreateMap<ProfessorViewModel, Professor>();

            //Responsável
            CreateMap<ResponsavelViewModel, Responsavel>();
            CreateMap<UpdateResponsavelCommand, Responsavel>();
            CreateMap<CreateResponsavelCommand, Responsavel>();
            CreateMap<UpdateAdministradorCommand, Administrador>();

            //Serie
            CreateMap<SerieViewModel, Serie>();
            CreateMap<CreateSerieCommand, Serie>();
            CreateMap<UpdateSerieCommand, Serie>();

            //Turma
            CreateMap<TurmaViewModel, Turma>();
            CreateMap<TurmaDisciplinaProfessorViewModel, TurmaDisciplinaProfessor>();

            /* Mapeamento para criação dos eventos no Handles com List. Ex: handlerCreateEscolas */
            CreateMap<EventsResult, CommandResult>();
        }
    }
}
