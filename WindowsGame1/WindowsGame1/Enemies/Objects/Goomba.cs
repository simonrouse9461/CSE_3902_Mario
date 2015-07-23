using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Goomba : ObjectKernel<GoombaStateController>, IEnemy
    {
        public Goomba()
        {
            CollisionHandler = new GoombaCollisionHandler(Core);
            BarrierHandler = new GoombaBarrierHandler(Core);
            BarrierHandler.AddBarrier<IBlock>();
        }

        public override bool Solid
        {
            get { return Alive; }
        }

        public bool Alive
        {
            get { return StateController.MotionState.isAlive(); }
        }

        public bool isMovingShell
        {
            get { return false; }
        }
    }
}
