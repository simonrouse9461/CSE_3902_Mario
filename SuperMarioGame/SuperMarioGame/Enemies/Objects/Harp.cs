using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Harp : ObjectKernelNew<HarpStateController>
    {
        public Harp()
        {
            CollisionHandler = new HarpCollisionHandler(Core);
        }
    }
}
