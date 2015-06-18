using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCollisionHandler : CollisionHandlerKernel<NormalBlockSpriteState, NormalBlockMotionState>
    {
        private CollisionDetector<MarioObject> MarioNormalBlockCollision;

        public NormalBlockCollisionHandler(NormalBlockSpriteState spriteState, NormalBlockMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize() {
            MarioNormalBlockCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle(){
            if(MarioNormalBlockCollision.Detect().Bottom){
                Object.Unload(0);
            }
        }
    }
}
