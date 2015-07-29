using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Fireflower : ObjectKernel<FireflowerStateController>, IItem
    {
        public Fireflower()
        {
            CollisionHandler = new FireflowerCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new FireflowerBarrierHandler(Core);
            SoundManager.ItemAppearSoundPlay();
            BarrierHandler.RemoveBarrier<IEnemy>();
        }
    }
}
