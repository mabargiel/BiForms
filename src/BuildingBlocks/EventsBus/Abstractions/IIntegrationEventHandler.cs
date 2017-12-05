using BTopService.BiForms.BuildingBlocks.EventBus.Events;

namespace BTopService.BiForms.BuildingBlocks.EventBus.Abstractions
{
    public interface IHandleEvents
    {
    }
    
    public interface IHandleEvents<TEvent> : IHandleEvents where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
