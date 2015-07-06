namespace WindowsGame1
{
    public abstract class StateControllerKernel<TSpriteState, TMotionState> : IStateController
        where TSpriteState : ISpriteState, new()
        where TMotionState : IMotionState, new()
    {
        public TSpriteState SpriteState { get; set; }
        public TMotionState MotionState { get; set; }
        public ISpriteState GeneralSpriteState { get { return SpriteState; } }
        public IMotionState GeneralMotionState { get { return MotionState; } }

        public ICore Core { protected get; set; }

        protected StateControllerKernel()
        {
            SpriteState = new TSpriteState();
            MotionState = new TMotionState();
        }

        protected abstract void UpdateState();

        public void Update()
        {
            UpdateState();
            SpriteState.Update();
            MotionState.Update();
        }
    }
}