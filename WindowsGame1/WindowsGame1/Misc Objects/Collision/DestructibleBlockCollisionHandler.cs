using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class DestructibleBlockCollisionHandler : CollisionHandlerKernel<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {
        private CollisionDetector<MarioObject> MarioDestructibleBlockCollision;

        public DestructibleBlockCollisionHandler(DestructibleBlockSpriteState spriteState, DestructibleBlockMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            MarioDestructibleBlockCollision = new CollisionDetector<MarioObject>(Object);
        }

        public override void Handle()
        {
            if (MarioDestructibleBlockCollision.Detect().Bottom)
            {
                SpriteState.DestructibleDestroyed();
            }
        }
    }
}
