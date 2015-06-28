using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class ItemCollisionHandler : CollisionHandlerKernel<ItemSpriteState, ItemMotionState>
    {
        public ItemCollisionHandler(State<ItemSpriteState, ItemMotionState> state) : base(state)
        {
            State.BarrierDetector.AddBarrier<IObject>();
            State.BarrierDetector.RemoveBarrier<IMario>();
        }

        public override void Handle()
        {
            if (Detector.Detect<IMario>().AnyEdge.Touch)
            {
                State.Object.Unload();
            }
        }
    }
}