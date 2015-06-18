using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernel<ItemSpriteState, ItemMotionState>
    {
        public Star(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new StarSpriteState();
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
