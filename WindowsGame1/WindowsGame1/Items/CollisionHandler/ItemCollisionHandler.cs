using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class ItemCollisionHandler : CollisionHandlerKernelNew<ItemSpriteState, ItemMotionState>
    {
        IObject Obj;
        public ItemCollisionHandler(State<ItemSpriteState, ItemMotionState> state, IObject obj) : base(state)
        {
            AddBarrier<IObject>();
            this.Obj = obj;
        }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>().AnySide.Contact)
            {
                Obj.Unload();
            }
        }
    }
}