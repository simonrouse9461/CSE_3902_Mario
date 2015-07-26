using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballStateController : StateControllerKernelNew<SuperFireballSpriteState, SuperFireballMotionState>
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
            Core.BarrierHandler.RemoveBarrier<IObject>();
            MotionState.Freeze();
            SpriteState.Explode();
            SpriteState.HoldTillFinish(true, 1, () => Core.Object.Unload(true));
            SoundManager.FireworkSoundPlay();
        }
    }
}
