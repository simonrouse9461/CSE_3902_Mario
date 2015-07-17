﻿using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class OneUpMotionState : MotionStateKernelNew

    {
        public bool Gravity { get; private set; }

        public OneUpMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(MoveLeftMotion.ItemVelocity),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new RaiseUpMotion()),
                new StatusSwitch<IMotion>(MoveRightMotion.ItemVelocity)
            };
            LoseGravity();
            SetDefaultHorizontal();
            SetDefaultVertical();
        }

        public void SetDefaultHorizontal()
        {
            FindMotion<MoveLeftMotion>().Toggle(false);
            FindMotion<MoveRightMotion>().Toggle(false);
        }

        public void SetDefaultVertical()
        {
            FindMotion<RaiseUpMotion>().Toggle(false);
        }

        public void Generated()
        {
            FindMotion<RaiseUpMotion>().Toggle(true);
        }

        public void Moving()
        {
            FindMotion<RaiseUpMotion>().Toggle(false);
            FindMotion<MoveRightMotion>().Toggle(true);
        }

        public void ObtainGravity()
        {
            FindMotion<GravityMotion>().Toggle(true);
            Gravity = true;
        }

        public void LoseGravity()
        {
            FindMotion<GravityMotion>().Toggle(false);
            Gravity = false;
        }

        public bool isGenerating
        {
            get
            {
                return FindMotion<RaiseUpMotion>().Status;
            }
        }

        public void ChangeDirection()
        {
            if (FindMotion<MoveRightMotion>().Status)
            {
                FindMotion<MoveRightMotion>().Toggle(false);
                FindMotion<MoveLeftMotion>().Toggle(true);
            }
            else
            {
                FindMotion<MoveLeftMotion>().Toggle(false);
                FindMotion<MoveRightMotion>().Toggle(true);
            }
        }
    }
}
