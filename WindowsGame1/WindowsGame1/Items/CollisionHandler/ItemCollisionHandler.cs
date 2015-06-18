using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class ItemCollisionHandler : CollisionHandlerKernel<ItemSpriteState, ItemMotionState>
    {
        private CollisionDetector<MarioObject> ItemMarioCollision;

        public ItemCollisionHandler(ItemSpriteState spriteState, ItemMotionState motionState, IObject obj) : base(spriteState, motionState, obj) { }

        protected override void Initialize()
        {
            ItemMarioCollision = new CollisionDetector<MarioObject>(Object);
        }


        public override void Handle()
        {
            if (ItemMarioCollision.Detect().Any())
            {
                Object.Unload(0);
            }
        }
    }
}