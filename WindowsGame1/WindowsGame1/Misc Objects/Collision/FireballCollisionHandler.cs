using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
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
            if (Detector.Detect<IEnemy>().AnyEdge.Touch)
            {
                Core.SpriteState.Exploded();
                Core.MotionState.Stop();
                Core.DelayCommand(() => Core.Object.Unload(), 3);
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
