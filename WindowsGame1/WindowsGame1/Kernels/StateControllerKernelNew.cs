using System;

namespace WindowsGame1
{
    public abstract class StateControllerKernelNew<TSpriteState, TMotionState> : IStateControllerNew
        where TSpriteState : ISpriteStateNew, new()
        where TMotionState : IMotionState, new()
    {
        public TSpriteState SpriteState { get; set; }
        public TMotionState MotionState { get; set; }
        public ISpriteStateNew GeneralSpriteState { get { return SpriteState; } }
        public IMotionState GeneralMotionState { get { return MotionState; } }

        public ICoreNew Core { protected get; set; }

        protected StateControllerKernelNew()
        {
            SpriteState = new TSpriteState {Core = Core};
            MotionState = new TMotionState();
        }

        public virtual void Update() { } 

        public void RefreshState()
        {
            SpriteState.Update();
            MotionState.Update();
        }

        public void SwitchComponent(object component)
        {
            if (component is TSpriteState)
                SpriteState = (TSpriteState)component;
            if (component is TMotionState)
                MotionState = (TMotionState)component;
        }
    }
}