using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class OneUp : ObjectKernelNew<OneUpStateController>, IItem
    {
        public OneUp()
        {
            CollisionHandler = new OneUpCollisionHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

        public static OneUp MakeOneUp
        {
            get
            {
                var instance = new OneUp();
                instance.Core.StateController.MotionState.Generated();
                return instance;
            }
        }
    }
}
