using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HarpCollisionHandler : CollisionHandlerKernel<HarpStateController>
    {
        public HarpCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<IFireball>().AnyEdge.Touch)
            {
                Core.StateController.Die();
            }
        }
    }
}