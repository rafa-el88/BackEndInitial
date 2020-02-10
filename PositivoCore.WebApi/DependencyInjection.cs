using Microsoft.Extensions.DependencyInjection;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Aluno;
using PositivoCore.Application.Handler;
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
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<INivelEnsinoRepository, NivelEnsinoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurmaDisciplinaProfessorRepository, TurmaDisciplinaProfessorRepository>();
        }
        public static void ConfigureHandler(IServiceCollection services)
        {
            //Aluno
            services.AddScoped<IHandler<CreateAlunoCommand>, AlunoHandler>();
            services.AddScoped<IHandler<UpdateAlunoCommand>, AlunoHandler>();
            services.AddScoped<IHandler<DeleteAlunoCommand>, AlunoHandler>();
            services.AddScoped<IHandler<CreateListStudentsCommand>, AlunoHandler>();
            services.AddScoped<IHandler<UpdateListStudentsCommand>, AlunoHandler>();
            services.AddScoped<IHandler<DeleteListStudentsCommand>, AlunoHandler>();

            //Disciplina           
            services.AddScoped<IHandler<CreateDisciplinaCommand>, DisciplinaHandler>();
            services.AddScoped<IHandler<UpdateDisiplinaCommand>, DisciplinaHandler>();
            services.AddScoped<IHandler<DeleteDisciplinaCommand>, DisciplinaHandler>();
            
            //Escola
            services.AddScoped<IHandler<CreateEscolaCommand>, EscolaHandler>();
            services.AddScoped<IHandler<UpdateEscolaCommand>, EscolaHandler>();
            services.AddScoped<IHandler<DeleteEscolaCommand>, EscolaHandler>();
            services.AddScoped<IHandler<CreateEscolasCommand>, EscolaHandler>();

            //NivelEnsino
            services.AddScoped<IHandler<CreateNivelEnsinoCommand>, NivelEnsinoHandler>();
            services.AddScoped<IHandler<UpdateNivelEnsinoCommand>, NivelEnsinoHandler>();
            services.AddScoped<IHandler<DeleteNivelEnsinoCommand>, NivelEnsinoHandler>();

            //Professor
            services.AddScoped<IHandler<CreateProfessorCommand>, ProfessorHandler>();
            services.AddScoped<IHandler<UpdateProfessorCommand>, ProfessorHandler>();
            services.AddScoped<IHandler<DeleteProfessorCommand>, ProfessorHandler>();

            //Serie
            services.AddScoped<IHandler<CreateSerieCommand>, SerieHandler>();
            services.AddScoped<IHandler<UpdateSerieCommand>, SerieHandler>();
            services.AddScoped<IHandler<DeleteSerieCommand>, SerieHandler>();

            //Turma
            services.AddScoped<IHandler<CreateTurmaCommand>, TurmaHandler>();
            services.AddScoped<IHandler<UpdateTurmaCommand>, TurmaHandler>();
            services.AddScoped<IHandler<DeleteTurmaCommand>, TurmaHandler>();
            services.AddScoped<IHandler<AttachTurmaDisciplinaProfessorCommand>, TurmaHandler>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoServices, AlunoServices>();
            services.AddScoped<IDisciplinaServices, DisciplinaServices>();
            services.AddScoped<IEscolaServices, EscolaServices>();
            services.AddScoped<INivelEnsinoServices, NivelEnsinoServices>();
            services.AddScoped<IProfessorServices, ProfessorServices>();
            services.AddScoped<ISerieServices, SerieServices>();
            services.AddScoped<ITurmaServices, TurmaServices>();
        }

        public static void ConfigureQuery(IServiceCollection services)
        {
            services.AddScoped<IAlunoQuery, AlunoQuery>();
            services.AddScoped<IDisciplinaQuery, DisciplinaQuery>();
            services.AddScoped<IEscolaQuery, EscolaQuery>();
            services.AddScoped<INivelEnsinoQuery, NivelEnsinoQuery>();
            services.AddScoped<IProfessorQuery, ProfessorQuery>();
            services.AddScoped<ISerieQuery, SerieQuery>();
            services.AddScoped<ITurmaQuery, TurmaQuery>();
        }
    }
}

