using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HiddenBlockCollisionHandler : CollisionHandlerKernel<HiddenBlockSpriteState, HiddenBlockMotionState>
    {
        private CollisionDetector<MarioObject> MarioHiddenBlockCollision;

        public HiddenBlockCollisionHandler(HiddenBlockSpriteState spriteState, HiddenBlockMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioHiddenBlockCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle()
        {
            if (MarioHiddenBlockCollision.Detect().Bottom)
            {
                SpriteState.HiddenToUsedBlock();
            }
        }
    }
}
