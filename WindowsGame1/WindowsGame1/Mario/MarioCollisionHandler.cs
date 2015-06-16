using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector<GreenPipeObject> MarioPipeCollision;

        public MarioCollisionHandler(MarioSpriteState spriteState, MarioMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioPipeCollision = new CollisionDetector<GreenPipeObject>(Object);
        }

        public override void Handle()
        {
            if (MarioPipeCollision.Detect().Side())
            {
                SpriteState.BecomeDead();
            }
        }
    }
}