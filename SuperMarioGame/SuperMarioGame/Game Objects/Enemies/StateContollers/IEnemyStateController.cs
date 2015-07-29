namespace SuperMario
{
    public interface IEnemyStateController : IStateController
    {
        bool Dead { get; }
        bool NotMoving { get; }
        void KeepOnLand();
        void LiftOff();
        void Turn(Orientation orientation = Orientation.Default);
        void Flip();
        void MarioSmash();
    }
}