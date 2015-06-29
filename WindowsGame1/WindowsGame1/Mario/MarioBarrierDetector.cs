using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(IState state) : base(state) { }

        public override void Detect()
        {
            Func<int, Collision> collision = i => Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, i);
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch)
            {
                while (collision(0).Bottom.Touch)
                    State.GeneralMotionState.Adjust(new Vector2(0, -1));
                while ((collision(0).TopLeft & collision(0).TopRight).Touch)
                    State.GeneralMotionState.Adjust(new Vector2(0, 1));
                while ((collision(0).LeftTop & collision(0).LeftBottom).Touch || collision(0).Left.Touch && State.Object.GoingLeft)
                    State.GeneralMotionState.Adjust(new Vector2(1, 0));
                while ((collision(0).RightTop & collision(0).RightBottom).Touch || collision(0).Right.Touch && State.Object.GoingRight)
                    State.GeneralMotionState.Adjust(new Vector2(-1, 0));
                if (collision(0).TopRight.Touch && collision(0).TopLeft.None)
                    State.GeneralMotionState.Adjust(new Vector2(-2, 0));
                if (collision(0).RightTop.Touch && collision(0).RightBottom.None)
                    State.GeneralMotionState.Adjust(new Vector2(-2, 0));
                if (collision(0).TopLeft.Touch && collision(0).TopRight.None)
                    State.GeneralMotionState.Adjust(new Vector2(2, 0));
                if (collision(0).LeftTop.Touch && collision(0).LeftBottom.None)
                    State.GeneralMotionState.Adjust(new Vector2(2, 0));
            }
        }
    }
}