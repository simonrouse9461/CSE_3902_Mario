using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernelNew<CoinSpriteState, BlankMotionState>
    {
        public Coin(WorldManager world) : base(world) {  }
        protected override void Initialize()
        {
            SpriteState = new CoinSpriteState();
            MotionState = new BlankMotionState();
        }
        protected override void SyncState()
        {

        }
    }
}
