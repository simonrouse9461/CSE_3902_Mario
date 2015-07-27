namespace SuperMario
{
    public interface IEnemyMotionState : IMotionStateNew
    {
        Orientation Orientation { get; }
        void Flip();
        void Turn(Orientation orientation = Orientation.Default);
        void LoseGravity();
        void ObtainGravity();
    }
}