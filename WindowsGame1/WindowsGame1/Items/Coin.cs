using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernel<CoinStateController>, IItem
    {
        public Coin()
        {
            CollisionHandler = new CoinCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            SoundManager.CoinSoundPlay();
            
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }
    }
}
