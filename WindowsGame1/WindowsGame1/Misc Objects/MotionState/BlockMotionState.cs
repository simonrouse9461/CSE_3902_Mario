using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class BlockMotionState : MotionStateKernelNew
    {

        private enum VerticalEnum
        {
            Hit,
            None
        }

        public BlockMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(BounceUpMotion.BlockHit)
            };         
        }

        public void Hit()
        {
            FindMotion<BounceUpMotion>().Toggle(true);
        }

        public bool isHit
        {
            get { return FindMotion<BounceUpMotion>().Status; }
        }
    }
}
