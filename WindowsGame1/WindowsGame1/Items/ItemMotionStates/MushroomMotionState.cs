using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class MushroomMotionState : MotionStateKernel
    {
        public MushroomMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(new MoveLeftMotion().ItemVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().ItemVelocity),
                new StatusSwitch<IMotion>(new FallDownMotion())
            };
        }

        protected override void RefreshMotionStatus()
        {
            FindMotion<MoveLeftMotion>().Toggle(true);
            FindMotion<FallDownMotion>().Toggle(true);
        }

        protected override void SetToDefaultState()
        {
        }
    }
}
