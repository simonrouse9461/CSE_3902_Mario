using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernel<GoombaStateController>, IEnemy
    {
        public Goomba()
        {
            CollisionHandler = new GoombaCollisionHandler(Core);
            BarrierHandler = new GoombaBarrierHandler(Core);
            BarrierHandler.AddBarrier<IBlock>();
            //Core.BarrierHandler.AddBarrier<IBlock>();
            //Core.BarrierHandler.AddBarrier<IEnemy>();
        }

        public override bool Solid
        {
            get { return Alive; }
        }

        public bool Alive
        {
            get { return StateController.MotionState.isAlive(); }
        }
    }
}
