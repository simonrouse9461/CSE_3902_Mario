namespace SuperMario
{
    public interface IEnemyStateController : IStateControllerNew
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