namespace Infrastructure
{
    public interface IHandleEvents
    {
    }
    
    public interface IHandleEvents<TEvent> : IHandleEvents where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
