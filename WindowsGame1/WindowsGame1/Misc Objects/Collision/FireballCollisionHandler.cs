using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballCollisionHandler : CollisionHandlerKernelNew<FireballStateController>
    {

        public FireballCollisionHandler(ICore core) : base(core) {}

        public override void Handle()
        {          
            HandleObject();
        }

        protected virtual void HandleObject()
        {
            if (Core.CollisionDetector.Detect<IEnemy>().AnyEdge.Touch || Core.CollisionDetector.Detect<IObject>().AnySide.Touch)
            {
                Core.StateController.Explode();
                Core.DelayCommand(() => Core.Object.Unload(), 3);
            }
        }
    }
}
