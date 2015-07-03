using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(ICore core) : base(core) { }

//        public override void Detect()
//        {
//            Func<int, Collision> detect =
//                    i => Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, i);
//            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch)
//            {
//                Collision collision;
//                while (detect(0).Bottom.Touch)
//                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
//                for (collision = detect(0); (collision.TopLeft & collision.TopRight).Touch; collision = detect(0))
//                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
//                for (collision = detect(0);
//                    (collision.LeftTop & collision.LeftBottom).Touch ||
//                    collision.Left.Touch && Core.Object.GoingLeft;
//                    collision = detect(0))
//                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
//                for (collision = detect(0);
//                    (collision.RightTop & collision.RightBottom).Touch ||
//                    collision.Right.Touch && Core.Object.GoingRight;
//                    collision = detect(0))
//                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
//                collision = detect(0);
//                if (collision.TopRight.Touch && collision.TopLeft.None ||
//                    collision.RightTop.Touch && collision.RightBottom.None)
//                    Core.GeneralMotionState.Adjust(new Vector2(-2, 0));
//                collision = detect(0);
//                if (collision.TopLeft.Touch && collision.TopRight.None ||
//                    collision.LeftTop.Touch && collision.LeftBottom.None)
//                    Core.GeneralMotionState.Adjust(new Vector2(2, 0));
//            }
//        }
    }
}