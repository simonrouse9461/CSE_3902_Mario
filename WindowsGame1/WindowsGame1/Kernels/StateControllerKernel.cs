using System;

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

        public virtual void Update() { } 

        public void RefreshState()
        {
            SpriteState.Update();
            MotionState.Update();
        }

        public void SwitchComponent(Object component)
        {
            if (component is TSpriteState)
                SpriteState = (TSpriteState)component;
            if (component is TMotionState)
                MotionState = (TMotionState)component;
        }
    }
}