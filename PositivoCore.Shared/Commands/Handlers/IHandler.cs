using PositivoCore.Shared.Commands;
using System.Threading.Tasks;

namespace PositivoCore.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}