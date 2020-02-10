using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface ISerieServices
    {
        Task<IEnumerable<SerieViewModel>> GetAllSeries();
        Task<SerieViewModel> GetSerieByID(Guid idSerie);
        Task<IEnumerable<SerieViewModel>> GetSerieByNome(string nome);
        Task<ICommandResult> NewSerie(CreateSerieCommand command);
        Task<ICommandResult> UpdateSerie(UpdateSerieCommand command);
        Task<ICommandResult> DeletarSerie(Guid idSerie);
    }
}
