﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlankMotionState : MotionStateKernel
    {
        public BlankMotionState(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            base.Initialize(location);
            MotionList = new Dictionary<MotionKernel, bool>()
            {
                {new NullMotion(), false}
            };
        }
    }
}