using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FireballStateController : StateControllerKernel<FireballSpriteState, FireballMotionState>
    {
        public void ToLeft()
        {
            SpriteState.FaceLeft();
            MotionState.GoLeft();
        }

        public void ToRight()
        {
            SpriteState.FaceRight();
            MotionState.GoRight();
        }

        public void Explode()
        {
            MotionState.Stop();
            SpriteState.Explode();
            SpriteState.HoldTillFinish(false, SpriteHoldDependency.SpriteAnimation, () => Core.Object.Unload(true));
            Core.BarrierHandler.RemoveBarrier<IObject>();
        }

        public void Bounce()
        {
            MotionState.Bounce();
        }
    }
}
