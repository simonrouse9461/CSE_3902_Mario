using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class ItemCollisionHandler : CollisionHandlerKernel<SpriteStateKernel, MotionStateKernel>
    {
        public ItemCollisionHandler(ICore core) : base(core)
        {
            Core.BarrierDetector.AddBarrier<IObject>();
            Core.BarrierDetector.RemoveBarrier<IMario>();
        }

        public override void Handle()
        {
            if (Detector.Detect<IMario>().AnyEdge.Touch)
            {
                Core.Object.Unload();
            }
        }
    }
}