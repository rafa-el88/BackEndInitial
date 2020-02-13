using Microsoft.Extensions.DependencyInjection;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Aluno;
using PositivoCore.Application.Commands.ConvidadosEventos;
using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.Handler;
using PositivoCore.Application.Handlers;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.Queries;
using PositivoCore.Application.Services;
using PositivoCore.Data.Queries;
using PositivoCore.Data.Repositories;
using PositivoCore.Shared.Entities;
using PositivoCore.Shared.Handlers;

namespace PositivoCore.WebApi
{
    public static class DependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            ConfigureRepository(services);
            ConfigureHandler(services);
            ConfigureServices(services);
            ConfigureQuery(services);
        }
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IRepository<Entity>, Repository<Entity>>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IColecaoRepository, ColecaoRepository>();
            services.AddScoped<IDestinatarioMensagemRepository, DestinatarioMensagemRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<INivelEnsinoRepository, NivelEnsinoRepository>();
            services.AddScoped<IPeriodoRepository, PeriodoRepository>();
            services.AddScoped<IPeriodoLetivoConfiguracaoRepository, PeriodoLetivoConfiguracaoRepository>();
            services.AddScoped<IPeriodoLetivoTipoRepository, PeriodoLetivoTipoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IConvidadosEventoRepository, ConvidadosEventoRepository>();
            services.AddScoped<ITurmaDisciplinaProfessorRepository, TurmaDisciplinaProfessorRepository>();
        }
        public static void ConfigureHandler(IServiceCollection services)
        {
            //Administrador
            services.AddScoped<IHandler<CreateAdministradorCommand>, AdministradorHandler>();
            services.AddScoped<IHandler<UpdateAdministradorCommand>, AdministradorHandler>();
            services.AddScoped<IHandler<DeleteAdministradorCommand>, AdministradorHandler>();
            services.AddScoped<IHandler<CreateListAdministradoresCommand>, AdministradorHandler>();
            services.AddScoped<IHandler<UpdateListAdministradoresCommand>, AdministradorHandler>();
            services.AddScoped<IHandler<DeleteListAdministradoresCommand>, AdministradorHandler>();

            //Aluno
            services.AddScoped<IHandler<CreateAlunoCommand>, AlunoHandler>();
            services.AddScoped<IHandler<UpdateAlunoCommand>, AlunoHandler>();
            services.AddScoped<IHandler<DeleteAlunoCommand>, AlunoHandler>();
            services.AddScoped<IHandler<CreateListStudentsCommand>, AlunoHandler>();
            services.AddScoped<IHandler<UpdateListStudentsCommand>, AlunoHandler>();
            services.AddScoped<IHandler<DeleteListStudentsCommand>, AlunoHandler>();

            //Coleção
            services.AddScoped<IHandler<CreateColecaoCommand>, ColecaoHandler>();
            services.AddScoped<IHandler<UpdateColecaoCommand>, ColecaoHandler>();
            services.AddScoped<IHandler<DeleteColecaoCommand>, ColecaoHandler>();


            //Mensagem
            services.AddScoped<IHandler<CreateDestinatarioMensagemCommand>, DestinatarioMensagemHandler>();
            services.AddScoped<IHandler<UpdateDestinatarioMensagemCommand>, DestinatarioMensagemHandler>();
            services.AddScoped<IHandler<DeleteDestinatarioMensagemCommand>, DestinatarioMensagemHandler>();

            //Disciplina           
            services.AddScoped<IHandler<CreateDisciplinaCommand>, DisciplinaHandler>();
            services.AddScoped<IHandler<UpdateDisiplinaCommand>, DisciplinaHandler>();
            services.AddScoped<IHandler<DeleteDisciplinaCommand>, DisciplinaHandler>();

            //Escola
            services.AddScoped<IHandler<CreateEscolaCommand>, EscolaHandler>();
            services.AddScoped<IHandler<UpdateEscolaCommand>, EscolaHandler>();
            services.AddScoped<IHandler<DeleteEscolaCommand>, EscolaHandler>();
            services.AddScoped<IHandler<CreateEscolasCommand>, EscolaHandler>();

            //Mensagem
            services.AddScoped<IHandler<CreateMensagemCommand>, MensagemHandler>();
            services.AddScoped<IHandler<UpdateMensagemCommand>, MensagemHandler>();
            services.AddScoped<IHandler<DeleteMensagemCommand>, MensagemHandler>();

            //NivelEnsino
            services.AddScoped<IHandler<CreateNivelEnsinoCommand>, NivelEnsinoHandler>();
            services.AddScoped<IHandler<UpdateNivelEnsinoCommand>, NivelEnsinoHandler>();
            services.AddScoped<IHandler<DeleteNivelEnsinoCommand>, NivelEnsinoHandler>();

            //Periodo
            services.AddScoped<IHandler<CreatePeriodoCommand>, PeriodoHandler>();
            services.AddScoped<IHandler<UpdatePeriodoCommand>, PeriodoHandler>();
            services.AddScoped<IHandler<DeletePeriodoCommand>, PeriodoHandler>();

            //Periodo letivo configuração
            services.AddScoped<IHandler<CreatePeriodoLetivoConfiguracaoCommand>, PeriodoLetivoConfiguracaoHandler>();
            services.AddScoped<IHandler<UpdatePeriodoLetivoConfiguracaoCommand>, PeriodoLetivoConfiguracaoHandler>();
            services.AddScoped<IHandler<DeletePeriodoLetivoConfiguracaoCommand>, PeriodoLetivoConfiguracaoHandler>();

            //Periodo letivo tipo
            services.AddScoped<IHandler<CreatePeriodoLetivoTipoCommand>, PeriodoLetivoTipoHandler>();
            services.AddScoped<IHandler<UpdatePeriodoLetivoTipoCommand>, PeriodoLetivoTipoHandler>();
            services.AddScoped<IHandler<DeletePeriodoLetivoTipoCommand>, PeriodoLetivoTipoHandler>();

            //Professor
            services.AddScoped<IHandler<CreateProfessorCommand>, ProfessorHandler>();
            services.AddScoped<IHandler<UpdateProfessorCommand>, ProfessorHandler>();
            services.AddScoped<IHandler<DeleteProfessorCommand>, ProfessorHandler>();

            //Responsável
            services.AddScoped<IHandler<CreateResponsavelCommand>, ResponsavelHandler>();
            services.AddScoped<IHandler<UpdateResponsavelCommand>, ResponsavelHandler>();
            services.AddScoped<IHandler<DeleteResponsavelCommand>, ResponsavelHandler>();

            //Serie
            services.AddScoped<IHandler<CreateSerieCommand>, SerieHandler>();
            services.AddScoped<IHandler<UpdateSerieCommand>, SerieHandler>();
            services.AddScoped<IHandler<DeleteSerieCommand>, SerieHandler>();

            //Turma
            services.AddScoped<IHandler<CreateTurmaCommand>, TurmaHandler>();
            services.AddScoped<IHandler<UpdateTurmaCommand>, TurmaHandler>();
            services.AddScoped<IHandler<DeleteTurmaCommand>, TurmaHandler>();
            services.AddScoped<IHandler<AttachTurmaDisciplinaProfessorCommand>, TurmaHandler>();

            //ConvidadosEvento
            services.AddScoped<IHandler<CreateConvidadosEventoCommand>, ConvidadosEventoHandler>();
            services.AddScoped<IHandler<UpdateConvidadosEventoCommand>, ConvidadosEventoHandler>();
            services.AddScoped<IHandler<DeleteConvidadosEventoCommand>, ConvidadosEventoHandler>();
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAdministradorServices, AdministradorServices>();
            services.AddScoped<IAlunoServices, AlunoServices>();
            services.AddScoped<IColecaoServices, ColecaoServices>();
            services.AddScoped<IDestinatarioMensagemServices, DestinatarioMensagemServices>();
            services.AddScoped<IDisciplinaServices, DisciplinaServices>();
            services.AddScoped<IEscolaServices, EscolaServices>();
            services.AddScoped<IMensagemServices, MensagemServices>();
            services.AddScoped<INivelEnsinoServices, NivelEnsinoServices>();
            services.AddScoped<IPeriodoServices, PeriodoServices>();
            services.AddScoped<IPeriodoLetivoConfiguracaoServices, PeriodoLetivoConfiguracaoServices>();
            services.AddScoped<IPeriodoLetivoTipoServices, PeriodoLetivoTipoServices>();
            services.AddScoped<IProfessorServices, ProfessorServices>();
            services.AddScoped<IResponsavelServices, ResponsavelServices>();
            services.AddScoped<ISerieServices, SerieServices>();
            services.AddScoped<ITurmaServices, TurmaServices>();
            services.AddScoped<IConvidadosEventoServices, ConvidadosEventoServices>();
        }
        public static void ConfigureQuery(IServiceCollection services)
        {
            services.AddScoped<IAdministradorQuery, AdministradorQuery>();
            services.AddScoped<IAlunoQuery, AlunoQuery>();
            services.AddScoped<IColecaoQuery, ColecaoQuery>();
            services.AddScoped<IDestinatarioMensagemQuery, DestinatarioMensagemQuery>();
            services.AddScoped<IDisciplinaQuery, DisciplinaQuery>();
            services.AddScoped<IEscolaQuery, EscolaQuery>();
            services.AddScoped<IMensagemQuery, MensagemQuery>();
            services.AddScoped<INivelEnsinoQuery, NivelEnsinoQuery>();
            services.AddScoped<IPeriodoQuery, PeriodoQuery>();
            services.AddScoped<IPeriodoLetivoConfiguracaoQuery, PeriodoLetivoConfiguracaoQuery>();
            services.AddScoped<IPeriodoLetivoTipoQuery, PeriodoLetivoTipoQuery>();
            services.AddScoped<IProfessorQuery, ProfessorQuery>();
            services.AddScoped<IResponsavelQuery, ResponsavelQuery>();
            services.AddScoped<ISerieQuery, SerieQuery>();
            services.AddScoped<ITurmaQuery, TurmaQuery>();
            services.AddScoped<IConvidadosEventoQuery, ConvidadosEventoQuery>();
        }
    }
}

