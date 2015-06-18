using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class EnemyCollisionHandler : CollisionHandlerKernel<EnemySpriteState, EnemyMotionState>
    {
        private CollisionDetector<MarioObject> EnemyMarioCollision;

        public EnemyCollisionHandler(EnemySpriteState spriteState, EnemyMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            EnemyMarioCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle()
        {
            if (EnemyMarioCollision.Detect().Top)
            {
                SpriteState.MarioSmash();
                Object.Active = false;
                if (Object is Goomba)
                {
                    Object.Unload(200);
                }
            }
        }
    }
}