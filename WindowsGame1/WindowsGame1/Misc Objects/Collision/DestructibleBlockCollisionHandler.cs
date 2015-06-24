using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class DestructibleBlockCollisionHandler : CollisionHandlerKernelNew<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {


        public DestructibleBlockCollisionHandler(State<DestructibleBlockSpriteState, DestructibleBlockMotionState> state)
            : base(state)
        {
            AddBarrier<IObject>();
        }


        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Contact)
            {
                State.Object.Unload();
            }
        }
    }
}
