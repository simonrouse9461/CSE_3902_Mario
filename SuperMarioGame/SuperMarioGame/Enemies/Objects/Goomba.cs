using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Goomba : ObjectKernelNew<GoombaStateController>, IEnemy
    {
        public Goomba()
        {
            CollisionHandler = new GoombaCollisionHandler(Core);
            BarrierHandler = new EnemyBarrierHandler(Core);

            StateController.Turn(Orientation.Left);
            BarrierHandler.AddBarrier<IBlock>();
            Core.BarrierHandler.AddBarrier<IPipe>();
        }

        public override bool Solid
        {
            get { return Alive; }
        }

        public bool Alive
        {
            get { return !StateController.SpriteState.Dead; }
        }

        public bool CanKillMario
        {
            get { return Alive; }
        }
    }
}
