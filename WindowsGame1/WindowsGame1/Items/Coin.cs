using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernel<ItemSpriteState, ItemMotionState>
    {
        public Coin(WorldManager world) : base(world) {  }
        protected override void Initialize()
        {
            SpriteState = new CoinSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(SpriteState, MotionState, this);

            // make it not solid so that anything can pass through it
            Solid = false;
        }
        protected override void SyncState()
        {

        }
    }
}
