using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernelNew<ItemSpriteState, ItemMotionState>
    {
        public Coin(WorldManager world) : base(world)
        {
            SpriteState = new CoinSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(State, this);
        }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

        protected override void SyncState()
        {

        }
    }
}
