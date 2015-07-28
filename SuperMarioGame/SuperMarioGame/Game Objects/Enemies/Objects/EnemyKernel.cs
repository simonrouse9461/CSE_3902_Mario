namespace SuperMario
{
    public abstract class EnemyKernel<TStateController> : ObjectKernelNew<TStateController>, IEnemy
        where TStateController : IEnemyStateController, new()
    {
        protected EnemyKernel()
        {
            CollisionHandler = new EnemyCollisionHandler(Core);
            BarrierHandler = new EnemyBarrierHandler(Core);

            StateController.Turn(Orientation.Left);
            BarrierHandler.AddBarrier<IBlock>();
            Core.BarrierHandler.AddBarrier<IPipe>();
            Core.BarrierHandler.AddBarrier<IEnemy>();
        }

        public bool Alive
        {
            get { return !StateController.Dead; }
        }
    }
}