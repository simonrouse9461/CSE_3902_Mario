using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernel<NormalBlockSpriteState, NormalBlockMotionState>
    {
        public NormalBlockCollisionHandler(State<NormalBlockSpriteState, NormalBlockMotionState> state) : base(state) { }

        public override void Handle(){
            if (Detector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Contact)
            {
                State.Object.Unload();
            }
        }
    }
}
