using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HarpCollisionHandler : CollisionHandlerKernelNew<HarpStateController>
    {
        public HarpCollisionHandler(ICoreNew core) : base(core){}

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<IFireball>().AnyEdge.Touch)
            {
                Core.StateController.Die();
            }
        }
    }
}