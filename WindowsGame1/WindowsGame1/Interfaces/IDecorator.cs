namespace MarioGame
{
    public interface IDecorator
    {
        void Restore();
        void DelayRestore(int timeDelay);
    }
}