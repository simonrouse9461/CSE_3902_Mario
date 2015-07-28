using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class OneUp : ObjectKernelNew<OneUpStateController>, IItem
    {
        public OneUp()
        {
            CollisionHandler = new OneUpCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new OneUpBarrierHandler(Core);
            SoundManager.ItemAppearSoundPlay();
        }

        // make it not solid so that anything can pass through it
        public bool IsBarrier
        {
            get { return true; }
        }
    }
}
