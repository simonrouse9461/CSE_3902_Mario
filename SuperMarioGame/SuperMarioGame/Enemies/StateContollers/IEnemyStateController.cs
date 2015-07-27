namespace SuperMario
{
    public interface IEnemyStateController : IStateControllerNew
    {
        void KeepOnLand();
        void LiftOff();
        void Turn(Orientation orientation = Orientation.Default);
    }
}