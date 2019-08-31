using System.Threading.Tasks;
using OCTM.Domain.Core.Commands;
using OCTM.Domain.Core.Events;


namespace OCTM.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
