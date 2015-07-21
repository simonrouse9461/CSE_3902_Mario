using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class OneUp : ObjectKernel<OneUpStateController>, IItem
    {
        public OneUp()
        {
            CollisionHandler = new OneUpCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new OneUpBarrierHandler(Core);
            SoundManager.PowerUpAppearSoundPlay();
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return true; }
        }
    }
}
