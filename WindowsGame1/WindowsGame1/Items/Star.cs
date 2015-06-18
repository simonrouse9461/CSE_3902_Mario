using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernelNew<ItemSpriteState, ItemMotionState>
    {
        public Star(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new StarSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(SpriteState, MotionState, this);
        }
        protected override void SyncState()
        {

        }
    }
}
