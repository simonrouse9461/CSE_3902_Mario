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
                new MotionSwitch(new AccelerateRightMotion(0.1f, 5)),
                new MotionSwitch(new AccelerateLeftMotion(0.1f, 5))
            };
            HorizontalStatus = HorizontalEnum.None;
            VertialStatus = VerticalEnum.None;
        }

        protected override void RefreshState()
        {
            foreach (var motion in MotionList)
            {
                motion.Toggle(false);
            }
            switch (HorizontalStatus)
            {
                case HorizontalEnum.AccRight:
                    MotionList[0].Toggle(true);
                    break;
                case HorizontalEnum.AccLeft:
                    MotionList[1].Toggle(true);
                    break;
            }
        }

        protected override void ResetState()
        {
            if (HorizontalStatus == HorizontalEnum.None)
            {
                MotionList[0].Reset(Velocity);
                MotionList[1].Reset(Velocity);
            }
            else
            {
                HorizontalStatus = HorizontalEnum.None;
            }
        }

        public void MoveRight()
        {
            HorizontalStatus = IsLeft() ? HorizontalEnum.None : HorizontalEnum.AccRight;
        }

        public bool IsRight()
        {
            return HorizontalStatus == HorizontalEnum.AccRight;
        }

        public void MoveLeft()
        {
            HorizontalStatus = IsRight() ? HorizontalEnum.None : HorizontalEnum.AccLeft;
        }
        public bool IsLeft()
        {
            return HorizontalStatus == HorizontalEnum.AccLeft;
        }
    }
}