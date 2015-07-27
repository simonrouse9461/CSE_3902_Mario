namespace SuperMario
{
    public interface IEnemyStateController : IStateControllerNew
    {
        bool Dead { get; }

        void KeepOnLand();
        void LiftOff();
        void Turn(Orientation orientation = Orientation.Default);
        void Flip();
        void MarioSmash();
    }
}