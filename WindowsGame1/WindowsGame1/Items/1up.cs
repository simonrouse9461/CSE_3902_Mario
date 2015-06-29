using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class _1up : ObjectKernel<ItemSpriteState, ItemMotionState>, IItem
    {
        public _1up()
        {
            SpriteState = new _1UpSpriteState();
            MotionState = new ItemMotionState();
            CollisionHandler = new ItemCollisionHandler(Core);
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
