using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TSpriteState, TMotionState> : ICollisionHandler<TSpriteState, TMotionState> 
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected IObject Object;

        protected CollisionHandlerKernel(IObject obj)
        {
            Object = obj;
            Initialize();
        }

        protected abstract void Initialize();

        public abstract List<Action<TSpriteState, TMotionState>> GetAction();
    }
}