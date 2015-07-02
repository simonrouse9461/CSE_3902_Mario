namespace WindowsGame1
{
    public abstract class StateControllerKernel<TSpriteState, TMotionState> : IStateController 
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected Core<TSpriteState, TMotionState> Core;

        protected StateControllerKernel(ICore core)
        {
            if (core is Core<TSpriteState, TMotionState>)
                Core = (Core<TSpriteState, TMotionState>) core;
            else
                Core = new Core<TSpriteState, TMotionState>
                {
                    Object = core.Object,
                    SpriteState = (TSpriteState) (core.GeneralSpriteState),
                    MotionState = (TMotionState) (core.GeneralMotionState),
                    StateController = core.StateController,
                    CollisionHandler = core.CollisionHandler,
                    CommandExecutor = core.CommandExecutor,
                    BarrierDetector = core.BarrierDetector
                };
        }

        public abstract void SyncState();
        public abstract void Update();
    }
}