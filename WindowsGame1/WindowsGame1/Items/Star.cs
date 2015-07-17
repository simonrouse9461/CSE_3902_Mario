using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernel<StarStateController>, IItem
    {
        public Star()
        {
            CollisionHandler = new StarCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new StarBarrierHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return true; }
        }
    }
}
