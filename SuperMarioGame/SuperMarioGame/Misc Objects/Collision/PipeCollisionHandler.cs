using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class PipeCollisionHandler : CollisionHandlerKernel<BlockStateController>
    {

        public PipeCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingDown).Top.Cover)
            {
                WorldManager.SetWarpSection();
            }
        }
    }
}
