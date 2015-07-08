using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballStateController : StateControllerKernel<FireballSpriteState, FireballMotionState>
    {
        private Collision collision;
        public void Bounce()
        {
            if (BarrierCollision.Bottom.Touch)
            {
                MotionState.Bounce();
            }
        }

        public void Explode()
        {
            MotionState.Stop();
            SpriteState.Exploded();
            Core.BarrierDetector.RemoveBarrier<IObject>();
            Core.DelayCommand(() => Core.Object.Unload(), 6);
        }

        public void HitObject()
        {
            if (BarrierCollision.AnySide.Touch)
            {
                Explode();
            }
        }

        protected override void UpdateState()
        {
            collision = Core.CollisionDetector.Detect<IObject>();
            Bounce();
            HitObject();
        }
    }
}
