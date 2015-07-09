using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
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
