namespace WindowsGame1
{
    public interface ICommandHandler
    {
        void Reset();
        void ReadCommand(ICommand command);
        void Handle();
    }
}