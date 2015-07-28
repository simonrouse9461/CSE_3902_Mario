using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class FireballObject : ObjectKernelNew<FireballStateController>, IFireball
    {
        public FireballObject()
        {
            CollisionHandler = new FireballCollisionHandler(Core);
            BarrierHandler = new FireballBarrierHandler(Core);

            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<IMario>();
            BarrierHandler.RemoveBarrier<IFireball>();
            BarrierHandler.BecomeNonBarrier();
        }

        public static FireballObject LeftFireBall
        {
            get
            {
                var instance = new FireballObject();
                instance.Core.StateController.ToLeft();
                return instance;
            }
        }

        public static FireballObject RightFireBall
        {
            get
            {
                var instance = new FireballObject();
                instance.Core.StateController.ToRight();
                return instance;
            }
        }
    }
}
