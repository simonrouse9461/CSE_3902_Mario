using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernelNew<ItemSpriteState, ItemMotionState>
    {
        public Fireflower(WorldManager world) : base(world) { }
        protected override void Initialize() 
        {
            SpriteState = new FireflowerSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(SpriteState, MotionState, this);
        }
        protected override void SyncState()
        {

        }
    }
}
