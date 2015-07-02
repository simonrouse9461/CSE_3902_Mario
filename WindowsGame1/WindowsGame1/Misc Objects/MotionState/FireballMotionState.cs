﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class FireballMotionState : MotionStateKernel
    {
        private enum OrientationEnum
        {
            Left,
            Right
        }
        public FireballMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(new MoveLeftMotion().FireballVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().FireballVelocity),
                new StatusSwitch<IMotion>(new FallDownMotion())
            };
        }

        private OrientationEnum Orientation;
        protected override void RefreshMotionStatus()
        {
            switch (Orientation)
            {
                case OrientationEnum.Left:
                    FindMotion<MoveLeftMotion>().Toggle(true);
                    FindMotion<FallDownMotion>().Toggle(true);
                    break;
                case OrientationEnum.Right:
                    FindMotion<MoveRightMotion>().Toggle(true);
                    FindMotion<FallDownMotion>().Toggle(true);
                    break;
            }
        }

        protected override void SetToDefaultState()
        {

        }

        public void GoLeft()
        {
            Orientation = OrientationEnum.Left;
        }

        public void GoRight()
        {
            Orientation = OrientationEnum.Right;
        }

        public bool Left
        {
            get { return Orientation == OrientationEnum.Left; }
        }

        public bool Right
        {
            get { return Orientation == OrientationEnum.Right; }
        }
    }
}
