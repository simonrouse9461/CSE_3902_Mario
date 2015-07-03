using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public MarioMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(new AccelerateRightMotion(0.1f, 3)),
                new StatusSwitch<IMotion>(new AccelerateLeftMotion(0.1f, 3)),
                new StatusSwitch<IMotion>(new SuddenStopMotion(0.15f)),
                new StatusSwitch<IMotion>(new BounceUpMotion().MarioDie),
                new StatusSwitch<IMotion>(new BounceUpMotion().MarioJump),
                new StatusSwitch<IMotion>(new RaiseUpMotion()),
                new StatusSwitch<IMotion>(new GravityMotion())
            };

            HorizontalStatus = HorizontalEnum.None;
            VerticalStatus = VerticalEnum.None;
        }

        protected override void RefreshMotionStatus()
        {
            switch (HorizontalStatus)
            {
                case HorizontalEnum.AccRight:
                    if (MovingLeft)
                    {
                        FindMotion<SuddenStopMotion>().Toggle(true);
                    }
                    else
                    {
                        FindMotion<AccelerateRightMotion>().Toggle(true);
                    }
                    break;
                case HorizontalEnum.AccLeft:
                    if (MovingRight)
                    {
                        FindMotion<SuddenStopMotion>().Toggle(true);
                    }
                    else
                    {
                        FindMotion<AccelerateLeftMotion>().Toggle(true);
                    }
                    break;
                case HorizontalEnum.None:
                    if (MovingLeft || MovingRight)
                    {
                        FindMotion<SuddenStopMotion>().Toggle(true);
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
                    FindMotion<BounceUpMotion>(motion => motion.MarioDieVersion).Toggle(true);
                    break;
                case VerticalEnum.Raise:
                    FindMotion<BounceUpMotion>(motion => motion.MarioJumpVersion).Toggle(true);
                    break;
                case VerticalEnum.Fall:
                    FindMotion<GravityMotion>().Toggle(true);
                    break;
            }
        }

        protected override void SetToDefaultState()
        {
            HorizontalStatus = HorizontalEnum.None;
            if (VerticalStatus != VerticalEnum.Dead)
                VerticalStatus = VerticalEnum.Fall;
        }

        public bool HorizontalStatic
        {
            get { return Math.Abs(Velocity.X) < 0.001; }
        }

        public bool VerticalStatic
        {
            get { return Math.Abs(Velocity.Y) < 0.001; }
        }

        public void MoveRight()
        {
            HorizontalStatus = AcceleratingLeft ? HorizontalEnum.None : HorizontalEnum.AccRight;
        }

        public bool AcceleratingRight
        {
            get { return HorizontalStatus == HorizontalEnum.AccRight; }
        }

        public bool MovingRight
        {
            get { return Velocity.X > 0; }
        }

        public void MoveLeft()
        {
            HorizontalStatus = AcceleratingRight ? HorizontalEnum.None : HorizontalEnum.AccLeft;
        }

        public bool AcceleratingLeft
        {
            get { return HorizontalStatus == HorizontalEnum.AccLeft; }
        }

        public bool MovingLeft
        {
            get { return Velocity.X < 0; }
        }

        public void DeadFall()
        {
            HorizontalStatus = HorizontalEnum.None;
            VerticalStatus = VerticalEnum.Dead;
        }

        public bool Dead
        {
            get { return VerticalStatus == VerticalEnum.Dead; }
        }

        public void Raise()
        {
            VerticalStatus = VerticalEnum.Raise;
        }

        public bool Raising
        {
            get { return VerticalStatus == VerticalEnum.Raise; }
        }

        public void Fall()
        {
            VerticalStatus = VerticalEnum.Fall;
        }

        public bool Falling
        {
            get { return VerticalStatus == VerticalEnum.Fall; }
        }
    }
}