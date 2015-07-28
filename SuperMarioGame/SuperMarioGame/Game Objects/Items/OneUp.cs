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
    }
}
