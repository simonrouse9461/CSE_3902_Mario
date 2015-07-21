using System;
using System.Collections.Generic;

namespace MarioGame
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernel<BlockStateController>
    {

        public HiddenBlockCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch)
            {
                Core.StateController.HiddenBlockGive1Up();
            }
        }
    }
}
