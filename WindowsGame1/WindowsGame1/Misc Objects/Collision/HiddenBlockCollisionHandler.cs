using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernel<HiddenBlockSpriteState, HiddenBlockMotionState>
    {
        public HiddenBlockCollisionHandler(State<HiddenBlockSpriteState, HiddenBlockMotionState> state) : base(state) { }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Contact)
            {
                State.SpriteState.HiddenToUsedBlock();
            }
        }
    }
}
