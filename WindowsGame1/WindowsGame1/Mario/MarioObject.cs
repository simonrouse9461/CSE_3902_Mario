using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioObject : ObjectKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new MarioSpriteState();
            MotionState = new MarioMotionState(location);
        }
    }
}