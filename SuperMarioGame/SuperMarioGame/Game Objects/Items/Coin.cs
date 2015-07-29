using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace SuperMario
{
    public  class Coin : ObjectKernel<CoinStateController>, IItem
    {
        public Coin()
        {
            CollisionHandler = new CoinCollisionHandler(Core);
            Core.StateController.MotionState.Generated();
            SoundManager.CoinSoundPlay();
            
        }
    }
}
