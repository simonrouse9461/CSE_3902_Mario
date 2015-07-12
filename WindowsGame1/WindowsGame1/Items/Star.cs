using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernelNew<StarStateController>, IItem
    {
        public Star()
        {
            CollisionHandler = new StarCollisionHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

        public Star MakeStar
        {
            get
            {
                var instance = new Star();
                instance.Core.StateController.MotionState.Generated();
                return instance;
            }
        }
    }
}
