using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernel<ItemSpriteState, ItemMotionState>
    {
        public Mushroom(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new MushroomSpriteState();
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
