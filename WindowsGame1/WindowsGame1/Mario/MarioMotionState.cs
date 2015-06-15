using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioMotionState : MotionStateKernel
    {
        private enum HorizontalEnum
        {
            None,
            AccLeft,
            AccRight
        }

        private enum VerticalEnum
        {
            None,
            elevate,
            fall
        }

        private HorizontalEnum HorizontalStatus;
        private VerticalEnum VertialStatus;

        public MarioMotionState(Vector2 location) : base(location) { }

        protected override void Initialize()
        {
            MotionList = new List<MotionSwitch>
            {
                new MotionSwitch(new AccelerateRightMotion(0.1f, 3)),
                new MotionSwitch(new AccelerateLeftMotion(0.1f, 3)),
                new MotionSwitch(new SuddenStopMotion(0.15f))
            };
            HorizontalStatus = HorizontalEnum.None;
            VertialStatus = VerticalEnum.None;
        }

        protected override void RefreshMotionList()
        {
            switch (HorizontalStatus)
            {
                case HorizontalEnum.AccRight:
                    if (IsVelLeft())
                    {
                        MotionList[2].Toggle(true);
                    }
                    else
                    {
                    MotionList[0].Toggle(true);
                    }
                    break;
                case HorizontalEnum.AccLeft:
                    if (IsVelRight())
                    {
                        MotionList[2].Toggle(true);
                    }
                    else
                    {
                        MotionList[1].Toggle(true);
                    }
                    break;
                case HorizontalEnum.None:
                    if (IsVelLeft() || IsVelRight())
                    {
                        MotionList[2].Toggle(true);
                    }
                    break;
            }
        }

        protected override void ResetState()
        {
            HorizontalStatus = HorizontalEnum.None;
        }

        public void MoveRight()
        {
            HorizontalStatus = IsAccLeft() ? HorizontalEnum.None : HorizontalEnum.AccRight;
        }

        public bool IsAccRight()
        {
            return HorizontalStatus == HorizontalEnum.AccRight;
        }

        public bool IsVelRight()
        {
            return Velocity.X > 0;
        }

        public void MoveLeft()
        {
            HorizontalStatus = IsAccRight() ? HorizontalEnum.None : HorizontalEnum.AccLeft;
        }
        public bool IsAccLeft()
        {
            return HorizontalStatus == HorizontalEnum.AccLeft;
        }

        public bool IsVelLeft()
        {
            return Velocity.X < 0;
        }
    }
}