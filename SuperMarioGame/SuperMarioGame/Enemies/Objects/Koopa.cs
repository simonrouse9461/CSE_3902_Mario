using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public  class Koopa : ObjectKernelNew<KoopaStateController>, IEnemy
    {
        public Koopa()
        {
            CollisionHandler = new KoopaCollisionHandler(Core);
            BarrierHandler = new KoopaBarrierHandler(Core);
            BarrierHandler.AddBarrier<IBlock>();
        }

        public override bool Solid
        {
            get { return Alive; }
        }

        public bool Alive
        {
            get { return !StateController.SpriteState.Dead; }
        }

        public bool isMovingShell
        {
            get { return StateController.SpriteState.Dead && StateController.MotionState.IsMovingShell; }
        }
    }
}
