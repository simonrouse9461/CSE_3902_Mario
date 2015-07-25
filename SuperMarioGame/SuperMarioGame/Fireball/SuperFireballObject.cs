using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class SuperFireballObject : ObjectKernelNew<SuperFireballStateController>
    {
        public SuperFireballObject(){
             CollisionHandler = new SuperFireballCollisionHandler;

        }

        public static SuperFireballObject LeftSuperFireball
        {
            get
            {
                var instance = new SuperFireballObject();
                instance.Core.StateController.MotionState.GoLeft();
                return instance;
            }
        }

        public static SuperFireballObject RightSuperFireball
        {
            get
            {
                var instance = new SuperFireballObject();
                instance.Core.StateController.MotionState.GoRight();
                return instance;
            }
        }
       
    }
}
