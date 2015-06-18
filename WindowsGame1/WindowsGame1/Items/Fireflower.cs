using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<ItemSpriteState, ItemMotionState>
    {
        public Fireflower(WorldManager world) : base(world) { }
        protected override void Initialize() 
        {
            SpriteState = new FireflowerSpriteState();
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
