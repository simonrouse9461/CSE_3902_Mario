using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(ICore core) : base(core) { }

        public override void Detect()
        {
            Func<int, Collision> detect =
                    i => Core.CollisionDetector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, i);
            var collision = detect(0);
            if (collision.AnyEdge.Touch)
            {
                Collision c;
                while (detect(0).Bottom.Touch)
                {
                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
                }
                for (c = detect(0); (c.TopLeft & c.TopRight).Touch; c = detect(0))
                {
                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
                }
                for (c = detect(0);
                    c.Left.Touch && Core.Object.GoingLeft;
                    c = detect(0))
                {
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
                }
                for (c = detect(0);
                    c.Right.Touch && Core.Object.GoingRight;
                    c = detect(0))
                {
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                }
                c = detect(0);
                if (c.TopRight.Touch && c.TopLeft.None ||
                    c.Right.Touch && Core.Object.GoingUp)
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                c = detect(0);
                if (c.TopLeft.Touch && c.TopRight.None ||
                    c.Left.Touch && Core.Object.GoingUp)
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
            }
        }
    }
}