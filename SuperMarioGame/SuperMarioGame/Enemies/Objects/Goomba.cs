using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Goomba : ObjectKernelNew<GoombaStateController>, IEnemy
    {
        public Goomba()
        {
            CollisionHandler = new GoombaCollisionHandler(Core);
            BarrierHandler = new GoombaBarrierHandler(Core);

            StateController.Turn(Orientation.Left);
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
            get { return false; }
        }
    }
}
