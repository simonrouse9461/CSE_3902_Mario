using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class FireballObject : ObjectKernel<FireballStateController>
    {
        public FireballObject()
        {
            CollisionHandler = new FireballCollisionHandler(Core);
            BarrierHandler = new FireBallBarrierHandler(Core);

            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<MarioObject>();
        }

        // Versions

        public static FireballObject LeftFireBall
        {
            get
            {
                var instance = new FireballObject();
                instance.Core.StateController.MotionState.GoLeft();
                return instance;
            }
        }

        public static FireballObject RightFireBall
        {
            get
            {
                var instance = new FireballObject();
                instance.Core.StateController.MotionState.GoRight();
                return instance;
            }
        }
    }
}
