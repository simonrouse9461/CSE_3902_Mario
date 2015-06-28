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
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Contact)
            {
                while (collision().Bottom.Contact)
                    MotionState.Adjust(new Vector2(0, -1));
                while ((collision().TopLeft & collision().TopRight).Contact)
                    MotionState.Adjust(new Vector2(0, 1));
                while ((collision().LeftTop & collision().LeftBottom).Contact || collision().Left.Contact && Object.GoingLeft)
                    MotionState.Adjust(new Vector2(1, 0));
                while ((collision().RightTop & collision().RightBottom).Contact || collision().Right.Contact && Object.GoingRight)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision().TopRight.Contact && collision().TopLeft.None)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision().RightTop.Contact && collision().RightBottom.None)
                    MotionState.Adjust(new Vector2(-1, 0));
                if (collision().TopLeft.Contact && collision().TopRight.None)
                    MotionState.Adjust(new Vector2(1, 0));
                if (collision().LeftTop.Contact && collision().LeftBottom.None)
                    MotionState.Adjust(new Vector2(1, 0));
            }
        }
    }
}