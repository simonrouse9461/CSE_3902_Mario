using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballStateController : StateControllerKernel<FireballSpriteState, FireballMotionState>
    {
        public void Bounce()
        {
            if (BarrierCollision.Top.Touch)
            {
                MotionState.Bounce();
            }
        }

        public void Explode()
        {
            MotionState.Stop();
            SpriteState.Exploded();
            Core.DelayCommand(() => Core.Object.Unload(), 3);
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
            Bounce();
            HitObject();
        }
    }
}
