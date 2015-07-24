using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class FireballCollisionHandler : CollisionHandlerKernelNew<FireballStateController>
    {

        public FireballCollisionHandler(ICoreNew core) : base(core) {}

        public override void Handle()
        {          
            HandleObject();
        }

        protected virtual void HandleObject()
        {
            if (Core.CollisionDetector.Detect<IEnemy>().AnyEdge.Touch)
            {
                Core.StateController.Explode();
            }
        }
    }
}
