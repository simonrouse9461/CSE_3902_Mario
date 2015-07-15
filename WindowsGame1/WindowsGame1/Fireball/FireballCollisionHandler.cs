using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballCollisionHandler : CollisionHandlerKernel<FireballStateController>
    {

        public FireballCollisionHandler(ICore core) : base(core) {}

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
