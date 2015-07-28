using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Star : ObjectKernelNew<StarStateController>, IItem
    {
        public Star()
        {
            CollisionHandler = new StarCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            BarrierHandler = new StarBarrierHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public bool IsBarrier
        {
            get { return true; }
        }
    }
}
