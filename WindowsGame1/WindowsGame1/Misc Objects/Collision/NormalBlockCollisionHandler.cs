using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernel<NormalBlockSpriteState, NormalBlockMotionState>
    {
        public NormalBlockCollisionHandler(Core<NormalBlockSpriteState, NormalBlockMotionState> core) : base(core) { }

        public override void Handle(){
            if (Detector.Detect<MarioObject>(mario => mario.Destructive).Bottom.Touch)
            {
                Core.Object.Unload();
            }
        }
    }
}
