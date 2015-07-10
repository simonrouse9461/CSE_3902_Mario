using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class MushroomMotionState : MotionStateKernel
    {

        public bool Gravity { get; private set; }

        public MushroomMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(MoveLeftMotion.ItemVelocity),
                new StatusSwitch<IMotion>(new GravityMotion())
            };
        }

        protected override void RefreshMotionStatus()
        {
            FindMotion<MoveLeftMotion>().Toggle(true);

            if (Gravity)
            {
                FindMotion<GravityMotion>().Toggle(true);
            }
            else
            {
                FindMotion<GravityMotion>().Toggle(false);
            }
            
        }

        protected override void SetToDefaultState()
        {
        }

        public void ObtainGravity()
        {
            Gravity = true;
        }

        public void LoseGravity()
        {
            Gravity = false;
        }
    }
}
