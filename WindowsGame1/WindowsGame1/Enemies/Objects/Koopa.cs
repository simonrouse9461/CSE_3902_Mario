using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernel<KoopaStateController>, IEnemy
    {
        public Koopa() {
            CollisionHandler = new KoopaCollisionHandler(Core);
            BarrierHandler = new KoopaBarrierHandler(Core);
            BarrierHandler.AddBarrier<IBlock>();
        }

        public override bool Solid
        {
            get { return true; }
        }

        public bool Alive
        {
            get { return !StateController.SpriteState.Dead; }
        }

        public bool isMovingShell
        {
            get { return StateController.SpriteState.Dead && StateController.MotionState.isMoving; }
        }
    }
}
