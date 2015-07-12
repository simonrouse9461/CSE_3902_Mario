using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernelNew<CoinStateController>, IItem
    {
        public Coin()
        {
            CollisionHandler = new CoinCollisionHandler(Core);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

        public Coin MakeCoin
        {
            get
            {
                var instance = new Coin();
                instance.Core.StateController.MotionState.Generated();
                return instance;
            }
        }
    }
}
