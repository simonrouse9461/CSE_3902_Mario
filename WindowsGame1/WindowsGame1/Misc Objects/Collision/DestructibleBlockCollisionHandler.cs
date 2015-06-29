using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class DestructibleBlockCollisionHandler : CollisionHandlerKernel<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {
        public DestructibleBlockCollisionHandler(Core<DestructibleBlockSpriteState, DestructibleBlockMotionState> core) : base(core) { }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                Core.Object.Unload();
            }
        }
    }
}
