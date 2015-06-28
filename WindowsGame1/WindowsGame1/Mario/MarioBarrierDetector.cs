using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(IObject obj) : base(obj) { }

        public override void Detect()
        {
            Func<int, Collision> collision = i => Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, i);
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch)
            {
                while (collision(0).Bottom.Touch)
                    MotionState.Adjust(new Vector2(0, -1));
                while ((collision(0).TopLeft & collision(0).TopRight).Touch)
                    MotionState.Adjust(new Vector2(0, 1));
                while ((collision(0).LeftTop & collision(0).LeftBottom).Touch || collision(0).Left.Touch && Object.GoingLeft)
                    MotionState.Adjust(new Vector2(1, 0));
                while ((collision(0).RightTop & collision(0).RightBottom).Touch || collision(0).Right.Touch && Object.GoingRight)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision(0).TopRight.Touch && collision(0).TopLeft.None)
                    MotionState.Adjust(new Vector2(-2, 0));
                if (collision(0).RightTop.Touch && collision(0).RightBottom.None)
                    MotionState.Adjust(new Vector2(-2, 0));
                if (collision(0).TopLeft.Touch && collision(0).TopRight.None)
                    MotionState.Adjust(new Vector2(2, 0));
                if (collision(0).LeftTop.Touch && collision(0).LeftBottom.None)
                    MotionState.Adjust(new Vector2(2, 0));
            }
        }
    }
}