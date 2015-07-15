namespace WindowsGame1
{
    public interface IDecorator
    {
        void Restore();
        void DelayRestore(int timeDelay);
    }
}