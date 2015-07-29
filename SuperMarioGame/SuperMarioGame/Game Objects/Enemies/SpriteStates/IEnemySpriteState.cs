namespace SuperMario
{
    public interface IEnemySpriteState : ISpriteState
    {
        bool Dead { get; }
        void Flip();
    }
}