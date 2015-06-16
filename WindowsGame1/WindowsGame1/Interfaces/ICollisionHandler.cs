using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public interface ICollisionHandler<TSpriteState, TMotionState>
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        void Handle();
    }
}