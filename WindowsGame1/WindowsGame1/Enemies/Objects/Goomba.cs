using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernelNew<GoombaStateController>, IEnemy
    {
        public Goomba()
        {
            CollisionHandler = new GoombaCollisionHandler(Core);
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
