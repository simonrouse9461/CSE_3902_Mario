namespace SuperMario
{
    public interface IMario : IObject
    {
        bool Alive { get; }
        bool StarPower { get; }
        bool Destructive { get; }
        void Freeze();
    }
}