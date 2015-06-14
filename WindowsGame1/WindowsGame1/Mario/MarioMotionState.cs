using System.Collections.Generic;
using System.Linq;
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
            MotionList = new Dictionary<IMotion, bool>()
            {
                {new AccelerateRightMotion(1, 60), false}
            };
            HorizontalStatus = HorizontalEnum.None;
            VertialStatus = VerticalEnum.None;
        }

        protected override void RefreshState()
        {
            if (HorizontalStatus == HorizontalEnum.AccRight)
            {
                MotionList[MotionList.Keys.OfType<AccelerateRightMotion>().First()] = true;
            }

        }

        public void MoveRight()
        {
            HorizontalStatus = HorizontalEnum.AccRight;
        }
    }
}