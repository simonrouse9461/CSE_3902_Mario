using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockMotionState : MotionStateKernel
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
                new StatusSwitch<IMotion>(new BlockMotion())
            };         
        }

        protected override void RefreshMotionStatus()
        {
            if (VerticalStatus == VerticalEnum.Hit)
            {
                FindMotion<BlockMotion>();
            }
            
        }

        protected override void SetToDefaultState()
        {
            VerticalStatus = VerticalEnum.None;
        }

        public void Hit()
        {
            VerticalStatus = VerticalEnum.Hit;
        }

        public bool isHit
        {
            get { return VerticalStatus == VerticalEnum.Hit; }
        }
    }
}
