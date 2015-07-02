using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballObject : ObjectKernel<FireballSpriteState, FireballMotionState>
    {

        public FireballObject()
        {
            
            CollisionHandler = new FireballCollisionHandler(Core);
        }
        public override bool Solid
        {
            get { return false; }
        }

        public FireballObject LeftFireBall
        {
            get
            {
                Core.MotionState.GoLeft();
                return this;
            }
        }

        public FireballObject RightFireBall
        {
            get
            {
                Core.MotionState.GoRight();
                return this;
            }
        }
    }
}
