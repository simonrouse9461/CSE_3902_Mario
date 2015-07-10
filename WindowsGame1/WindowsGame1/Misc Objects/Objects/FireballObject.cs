using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballObject : ObjectKernelNew<FireballStateController>
    {

        public FireballObject()
        {
            CollisionHandler = new FireballCollisionHandler(Core);
            BarrierHandler = new FireBallBarrierHandler(Core);

            BarrierHandler.AddBarrier<IObject>();
            BarrierHandler.RemoveBarrier<MarioObject>();
        }

        public FireballObject LeftFireBall
        {
            get
            {
                Core.StateController.MotionState.GoLeft();
                return this;
            }
        }

        public FireballObject RightFireBall
        {
            get
            {
                Core.StateController.MotionState.GoRight();
                return this;
            }
        }
    }
}
