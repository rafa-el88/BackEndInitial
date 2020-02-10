using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Events;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Application.Mapper
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap()
        {
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<DisciplinaViewModel, Disciplina>();
            CreateMap<EscolaViewModel, Escola>();
            CreateMap<NivelEnsinoViewModel, NivelEnsino>();
            CreateMap<ProfessorViewModel, Professor>();
            CreateMap<SerieViewModel, Serie>();
            CreateMap<TurmaViewModel, Turma>();

            /* Mapeamento para criação dos eventos no Handles com List. Ex: handlerCreateEscolas */
            CreateMap<EventsResult, CommandResult>();
        }
    }
}
