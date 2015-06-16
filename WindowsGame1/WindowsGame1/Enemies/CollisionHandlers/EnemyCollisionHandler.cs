using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class EnemyCollisionHandler : CollisionHandlerKernel<EnemySpriteState, EnemyMotionState>
    {
        private CollisionDetector<MarioObject> GoombaMarioCollision;

        public EnemyCollisionHandler(EnemySpriteState spriteState, EnemyMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            GoombaMarioCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle()
        {
            if (GoombaMarioCollision.Detect().Top)
            {
                SpriteState.MarioSmash();
            }
        }
    }
}