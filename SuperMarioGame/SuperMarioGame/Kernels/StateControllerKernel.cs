using System;

namespace SuperMario
{
    public abstract class StateControllerKernel<TSpriteState, TMotionState> : IStateController
        where TSpriteState : ISpriteState, new()
        where TMotionState : IMotionState, new()
    {
        public TSpriteState SpriteState { get; set; }
        public TMotionState MotionState { get; set; }
        public ISpriteState GeneralSpriteState { get { return SpriteState; } }
        public IMotionState GeneralMotionState { get { return MotionState; } }

        private ICore _core;

        public ICore Core
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

        public void SwitchComponent(object component)
        {
            if (component is TSpriteState)
                SpriteState = (TSpriteState)component;
            if (component is TMotionState)
                MotionState = (TMotionState)component;
        }
    }
}