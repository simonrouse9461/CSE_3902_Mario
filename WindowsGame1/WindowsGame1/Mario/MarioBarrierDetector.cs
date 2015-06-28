using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(IObject obj) : base(obj) { }

        public override void Detect()
        {
            Func<Collision> collision = () => Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0);
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch)
            {
                while (collision().Bottom.Touch)
                    MotionState.Adjust(new Vector2(0, -1));
                while ((collision().TopLeft & collision().TopRight).Touch)
                    MotionState.Adjust(new Vector2(0, 1));
                while ((collision().LeftTop & collision().LeftBottom).Touch || collision().Left.Touch && Object.GoingLeft)
                    MotionState.Adjust(new Vector2(1, 0));
                while ((collision().RightTop & collision().RightBottom).Touch || collision().Right.Touch && Object.GoingRight)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision().TopRight.Touch && collision().TopLeft.None)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision().RightTop.Touch && collision().RightBottom.None)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision().TopLeft.Touch && collision().TopRight.None)
                    MotionState.Adjust(new Vector2(1, 0));
                if (collision().LeftTop.Touch && collision().LeftBottom.None)
                    MotionState.Adjust(new Vector2(1, 0));
            }
        }
    }
}