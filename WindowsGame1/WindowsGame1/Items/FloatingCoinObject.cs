using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace MarioGame
{
    public class FloatingCoinObject : ObjectKernel<CoinStateController>, IItem
    {

        public FloatingCoinObject()
        {
            CollisionHandler = new FloatingCoinCollisionHandler(Core);
        }

        public override bool Solid
        {
            get
            {
                return false;
            }
        }
    }
}
