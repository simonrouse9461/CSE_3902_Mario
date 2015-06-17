using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface ICollisionHandler<TSpriteState, TMotionState>
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        void Handle();
        void Validate();
    }
}