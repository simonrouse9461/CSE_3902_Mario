using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<ItemSpriteState, ItemMotionState>
    {
        public Fireflower(WorldManager world) : base(world) { }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

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
