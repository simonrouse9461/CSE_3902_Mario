namespace SuperMario
{
    public interface IDecorator
    {
        void Restore();
        void DelayRestore(int timeDelay);
    }
}