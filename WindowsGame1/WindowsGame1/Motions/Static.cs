﻿using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Static : MotionKernel
    {
        public override bool Finish
        {
            get { return true; }
        }

        public override Vector2 Velocity
        {
            get { return default(Vector2); }
        }
    }
}