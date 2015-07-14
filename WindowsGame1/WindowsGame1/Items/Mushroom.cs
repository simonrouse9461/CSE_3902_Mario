﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernelNew<MushroomStateController>, IItem
    {
        public Mushroom()
        {
            CollisionHandler = new MushroomCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return true; }
        }
    }
}
