using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernelNew<ItemSpriteState, ItemMotionState>
    {
        public Mushroom()
        {
            SpriteState = new MushroomSpriteState();
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
