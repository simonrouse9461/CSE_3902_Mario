using System;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class FireballStateController : StateControllerKernel<FireballSpriteState, FireballMotionState>
    {
        public void Explode()
        {
            MotionState.Stop();
            SpriteState.Exploded();
            Core.BarrierHandler.RemoveBarrier<IObject>();
            Core.DelayCommand(() => Core.Object.Unload(), 6);
        }

        public void Bounce()
        {
            MotionState.Bounce();
        }
    }
}
