using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class _1up : ObjectKernelNew<ItemSpriteState, ItemMotionState>
    {
        public _1up(WorldManager world) : base(world)
        {
            SpriteState = new _1UpSpriteState();
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
