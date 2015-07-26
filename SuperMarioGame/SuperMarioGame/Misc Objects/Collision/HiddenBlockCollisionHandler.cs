﻿using System;
using System.Collections.Generic;

namespace SuperMario
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernelNew<BlockStateController>
    {

        public HiddenBlockCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.GoingUp).Bottom.Touch && !Core.StateController.SpriteState.isUsed)
            {
                Core.StateController.GiveThings(true);
            }
        }
    }
}
