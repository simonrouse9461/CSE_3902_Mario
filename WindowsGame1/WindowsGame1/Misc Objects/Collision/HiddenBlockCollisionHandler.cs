using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernelNew<HiddenBlockSpriteState, HiddenBlockMotionState>
    {


        public HiddenBlockCollisionHandler(State<HiddenBlockSpriteState, HiddenBlockMotionState> state) : base(state) {

            AddBarrier<IObject>();
        }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Contact)
            {
                State.SpriteState.HiddenToUsedBlock();
            }
        }
    }
}
