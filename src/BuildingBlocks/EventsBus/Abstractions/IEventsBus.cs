using BTopService.BiForms.BuildingBlocks.EventBus.Events;

namespace BTopService.BiForms.BuildingBlocks.EventBus.Abstractions
{
    public interface IEventsBus
    {
        void Send<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
