using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<ItemSpriteState, ItemMotionState>, IItem
    {
        public Fireflower()
        {
            SpriteState = new FireflowerSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(State);
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
