using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Harp : ObjectKernel<HarpStateController>
    {
        public Harp()
        {
            CollisionHandler = new HarpCollisionHandler(Core);
        }
    }
}
