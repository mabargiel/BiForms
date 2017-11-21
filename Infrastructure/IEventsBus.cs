namespace Infrastructure
{
    public interface IEventsBus
    {
        void Send<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
