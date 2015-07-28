using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class PipeCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {
        public PipeCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<Mario>(mario => mario.GoingDown).Top.Cover)
            {
                WorldManager.SetWarpSection();
            }
        }
    }
}
