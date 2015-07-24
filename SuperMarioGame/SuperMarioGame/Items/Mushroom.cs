using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Mushroom : ObjectKernel<MushroomStateController>, IItem
    {
        public Mushroom()
        {
            CollisionHandler = new MushroomCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new MushroomBarrierHandler(Core);
            SoundManager.PowerUpAppearSoundPlay();
            BarrierHandler.RemoveBarrier<IEnemy>();
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return true; }
        }
    }
}
