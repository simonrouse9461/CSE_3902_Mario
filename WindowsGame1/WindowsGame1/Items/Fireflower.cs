﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernelNew<FireflowerStateController>, IItem
    {
        public Fireflower()
        {
            CollisionHandler = new FireflowerCollisionHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

        public Fireflower MakeFireflower
        {
            get
            {
                var instance = new Fireflower();
                instance.Core.StateController.MotionState.Generated();
                return instance;
            }
        }
    }
}
