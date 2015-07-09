using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierDetector : BarrierDetector
    {
        public MarioBarrierDetector(ICore core) : base(core) { }

        public override void Detect()
        {
            Func<Collision> detect =
                    () => Core.CollisionDetector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, 0);
            var collision = detect();
            if (collision.AnyEdge.Touch)
            {
                Collision c;
                while (detect().Bottom.Touch)
                {
                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
                }
                for (c = detect(); (c.TopLeft | c.TopRight).Cover; c = detect())
                {
                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
                }
                for (c = detect();
                    c.Left.Touch && Core.Object.GoingLeft;
                    c = detect())
                {
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
                }
                for (c = detect();
                    c.Right.Touch && Core.Object.GoingRight;
                    c = detect())
                {
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                }
                c = detect();
                if (c.TopRight.Touch && c.TopLeft.None ||
                    c.Right.Touch && Core.Object.GoingUp)
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                c = detect();
                if (c.TopLeft.Touch && c.TopRight.None ||
                    c.Left.Touch && Core.Object.GoingUp)
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
            }
        }
    }
}