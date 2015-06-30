using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(ICore core) : base(core) { }

        public override void Detect()
        {
            Func<int, Collision> collision = i => Detector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, i);
            if (Detector.Detect(BarrierList, BarrierExceptionList).AnyEdge.Touch)
            {
                while (collision(0).Bottom.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
                while ((collision(0).TopLeft & collision(0).TopRight).Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
                while ((collision(0).LeftTop & collision(0).LeftBottom).Touch || collision(0).Left.Touch && Core.Object.GoingLeft)
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
                while ((collision(0).RightTop & collision(0).RightBottom).Touch || collision(0).Right.Touch && Core.Object.GoingRight)
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                if (collision(0).TopRight.Touch && collision(0).TopLeft.None)
                    Core.GeneralMotionState.Adjust(new Vector2(-2, 0));
                if (collision(0).RightTop.Touch && collision(0).RightBottom.None)
                    Core.GeneralMotionState.Adjust(new Vector2(-2, 0));
                if (collision(0).TopLeft.Touch && collision(0).TopRight.None)
                    Core.GeneralMotionState.Adjust(new Vector2(2, 0));
                if (collision(0).LeftTop.Touch && collision(0).LeftBottom.None)
                    Core.GeneralMotionState.Adjust(new Vector2(2, 0));
            }
        }
    }
}