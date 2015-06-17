using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TSpriteState, TMotionState> : ICollisionHandler<TSpriteState, TMotionState> 
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected IObject Object;
        protected TSpriteState SpriteState;
        protected TMotionState MotionState;

        protected CollisionHandlerKernel(TSpriteState spriteState, TMotionState motionState, IObject obj)
        {
            SpriteState = spriteState;
            MotionState = motionState;
            Object = obj;
            Initialize();
        }

        protected abstract void Initialize();

        public abstract void Handle();

        public virtual void Validate()
        {
            
        }
    }
}