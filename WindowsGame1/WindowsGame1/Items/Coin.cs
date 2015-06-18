using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernelNew<ItemSpriteState, ItemMotionState>
    {
        public Coin(WorldManager world) : base(world) {  }
        protected override void Initialize()
        {
            SpriteState = new CoinSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(SpriteState, MotionState, this);
        }
        protected override void SyncState()
        {

        }
    }
}
