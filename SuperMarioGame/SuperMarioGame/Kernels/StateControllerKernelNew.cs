using System;

namespace SuperMario
{
    public abstract class StateControllerKernelNew<TSpriteState, TMotionState> : IStateControllerNew
        where TSpriteState : ISpriteStateNew, new()
        where TMotionState : IMotionStateNew, new()
    {
        public TSpriteState SpriteState { get; set; }
        public TMotionState MotionState { get; set; }
        public ISpriteStateNew GeneralSpriteState { get { return SpriteState; } }
        public IMotionStateNew GeneralMotionState { get { return MotionState; } }

        private ICoreNew _core;

        public ICoreNew Core
        {
            protected get
            {
                return _core;
            }
            set
            {
                _core = value;
                SpriteState.SetCore(value);
                MotionState.SetCore(value);
            }
        }

        protected StateControllerKernelNew()
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

        public void SwitchComponent(object component)
        {
            if (component is TSpriteState)
                SpriteState = (TSpriteState)component;
            if (component is TMotionState)
                MotionState = (TMotionState)component;
        }
    }
}