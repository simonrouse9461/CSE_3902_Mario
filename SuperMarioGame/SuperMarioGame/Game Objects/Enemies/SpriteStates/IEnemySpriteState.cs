namespace SuperMario
{
    public interface IEnemySpriteState : ISpriteStateNew
    {
        bool Dead { get; }
        void Flip();
    }
}