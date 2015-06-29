﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernel<IndestructibleBlockSpriteState, IndestructibleBlockMotionState>
    {
        public IndestructibleBlockObject() {

            SpriteState = new IndestructibleBlockSpriteState();
            MotionState = new IndestructibleBlockMotionState();
        }
   
        protected override void SyncState()
        {

        }
    }
}
