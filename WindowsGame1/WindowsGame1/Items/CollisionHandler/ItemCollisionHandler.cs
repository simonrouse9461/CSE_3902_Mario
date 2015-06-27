using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class ItemCollisionHandler : CollisionHandlerKernel<ItemSpriteState, ItemMotionState>
    {
        public ItemCollisionHandler(State<ItemSpriteState, ItemMotionState> state) : base(state)
        {
            State.BarrierDetector.AddBarrier<IObject>();
        }

        public override void Handle()
        {
            if (Detector.Detect<MarioObject>().AnyEdge.Contact)
            {
                State.Object.Unload();
            }
        }
    }
}