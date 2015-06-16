using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernel<GoombaSpriteState, GoombaMotionState>
    {
        private CollisionDetector<MarioObject> GoombaMarioCollision;

        public GoombaCollisionHandler(GoombaSpriteState spriteState, GoombaMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            GoombaMarioCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle()
        {
            if (GoombaMarioCollision.Detect().Top)
            {
                SpriteState.BecomeDead();
            }
        }
    }
}