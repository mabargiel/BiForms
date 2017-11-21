namespace Infrastructure
{
    public interface ICommandsBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
