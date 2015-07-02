using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Misc_Objects.Collision
{
    public class FireballCollisionHandler : CollisionHandlerKernel<FireballSpriteState, FireballMotionState>
    {

        public FireballCollisionHandler(Core<FireballSpriteState, FireballMotionState>core) : base(core) {}

        public override void Handle()
        {
            HandleEnemy();
            HandleBlock();
        }

        protected virtual void HandleEnemy()
        {
            if (Detector.Detect<IEnemy>(enemy => enemy.Alive).AnyEdge.Touch)
            {
                Core.SpriteState.Exploded();
            }
        }

        protected virtual void HandleBlock()
        {
            if (Detector.Detect<IBlock>(block => block.Solid).AnySide.Touch)
            {

            }
        }
    }
}
