using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class OneUp : ObjectKernelNew<OneUpStateController>, IItem
    {
        public OneUp()
        {
            CollisionHandler = new ItemCollisionHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }
    }
}
