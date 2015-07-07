using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballStateController : StateControllerKernel<FireballSpriteState, FireballMotionState>
    {

        private Collision collision;

        public void Bounce()
        {
            if (collision.Top.Touch)
            {
                MotionState.Bounce();
            }
        }

        public void Explode()
        {
            MotionState.Stop();
            SpriteState.Exploded();
        }

        public void HitObject()
        {
            if (collision.AnySide.Touch)
            {
                Explode();
            }
        }

        protected override void UpdateState()
        {
            HitObject();
            Bounce();
        }
    }
}
