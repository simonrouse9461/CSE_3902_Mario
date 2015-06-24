﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class UsedBlockObject : ObjectKernelNew<UsedBlockSpriteState, UsedBlockMotionState>
    {
        public UsedBlockObject(WorldManager world) : base(world) {

            SpriteState = new UsedBlockSpriteState();
            MotionState = new UsedBlockMotionState();
        }

        protected override void SyncState()
        {

        }
    }
}
