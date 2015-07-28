﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Star : ObjectKernelNew<StarStateController>, IItem
    {
        public Star()
        {
            CollisionHandler = new StarCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new StarBarrierHandler(Core);
        }
    }
}
