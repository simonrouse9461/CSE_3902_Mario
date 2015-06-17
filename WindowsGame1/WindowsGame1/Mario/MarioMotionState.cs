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
            Raise,
            Fall,
            Dead
        }

        private HorizontalEnum HorizontalStatus;
        private VerticalEnum VerticalStatus;

        protected override void Initialize()
        {
            MotionList = new List<MotionSwitch>
            {
                new MotionSwitch(new AccelerateRightMotion(0.1f, 3)), //0
                new MotionSwitch(new AccelerateLeftMotion(0.1f, 3)), //1
                new MotionSwitch(new SuddenStopMotion(0.15f)), //2
                new MotionSwitch(new DeadMotion()), //3
                new MotionSwitch(new RaiseUpMotion()), //4
                new MotionSwitch(new FallDownMotion()) //5
            };
            HorizontalStatus = HorizontalEnum.None;
            VerticalStatus = VerticalEnum.None;
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

            switch (VerticalStatus)
            {
                case VerticalEnum.Dead:
                    foreach (var motion in MotionList)
                    {
                        motion.Toggle(false);
                    }
                    MotionList[3].Toggle(true);
                    break;
                case VerticalEnum.Raise:
                    MotionList[4].Toggle(true);
                    break;
                case VerticalEnum.Fall:
                    MotionList[5].Toggle(true);
                    break;
            }
        }

        protected override void ResetState()
        {
            HorizontalStatus = HorizontalEnum.None;
            if (VerticalStatus != VerticalEnum.Dead)
                VerticalStatus = VerticalEnum.None;
        }

        public void StopHorizontal()
        {
            Velocity.X = 0;
//            HorizontalStatus = HorizontalEnum.None;
        }

        public bool IsHorizontalStatic()
        {
            return Math.Abs(Velocity.X) < 0.001;
        }

        public void StopVertical()
        {
            Velocity.Y = 0;
//            VerticalStatus = VerticalEnum.None;
        }

        public bool IsVerticalStatic()
        {
            return Math.Abs(Velocity.Y) < 0.001;
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

        public void Dead()
        {
            HorizontalStatus = HorizontalEnum.None;
            VerticalStatus = VerticalEnum.Dead;
        }

        public bool IsDead()
        {
            return VerticalStatus == VerticalEnum.Dead;
        }

        public void Raise()
        {
            VerticalStatus = VerticalEnum.Raise;
        }

        public bool IsRaise()
        {
            return VerticalStatus == VerticalEnum.Raise;
        }

        public void Fall()
        {
            VerticalStatus = VerticalEnum.Fall;
        }

        public bool IsFall()
        {
            return VerticalStatus == VerticalEnum.Fall;
        }
    }
}