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
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<Disciplina, DisciplinaViewModel>();
            CreateMap<Escola, EscolaViewModel>();
            CreateMap<NivelEnsino, NivelEnsinoViewModel>();
            CreateMap<Professor, ProfessorViewModel>();
            CreateMap<Serie, SerieViewModel>();
            CreateMap<Turma, TurmaViewModel>();

            /* Mapeamento para criação dos eventos no Handles com List. Ex: handlerCreateEscolas */
            CreateMap<CommandResult, EventsResult>();
        }
    }
}
