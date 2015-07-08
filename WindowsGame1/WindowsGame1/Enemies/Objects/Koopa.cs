using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernelNew<KoopaStateController>, IEnemy
    {
        public Koopa() {
            CollisionHandler = new KoopaCollisionHandler(Core);
            BarrierDetector = new MarioBarrierDetector(Core);
            BarrierDetector.AddBarrier<IBlock>();
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
