using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernel<HiddenBlockSpriteState, HiddenBlockMotionState>
    {
        public HiddenBlockCollisionHandler(Core<HiddenBlockSpriteState, HiddenBlockMotionState> core) : base(core) { }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                Core.SpriteState.HiddenToUsedBlock();
            }
        }
    }
}
