using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockMotionState : MotionStateKernelNew
    {

        private enum VerticalEnum
        {
            Hit,
            None
        }

        private VerticalEnum VerticalStatus;

        public BlockMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(BounceUpMotion.BlockHit)
            };         
        }

        public void Hit()
        {
            VerticalStatus = VerticalEnum.Hit;
            FindMotion<BounceUpMotion>().Toggle(true);
        }

        public bool isHit
        {
            get { return FindMotion<BounceUpMotion>().Status; }
        }
    }
}
