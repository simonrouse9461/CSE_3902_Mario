using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<FireflowerStateController>, IItem
    {
        public Fireflower()
        {
            CollisionHandler = new FireflowerCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new FireflowerBarrierHandler(Core);
            SoundManager.powerUpAppearSoundPlay();
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }
    }
}
