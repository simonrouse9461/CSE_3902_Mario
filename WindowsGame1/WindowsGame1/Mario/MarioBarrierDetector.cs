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
            if (detect(0).AnyEdge.Touch)
            {
                Collision collision;
                while (detect(0).Bottom.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
                for (collision = detect(0); (collision.TopLeft & collision.TopRight).Touch; collision = detect(0))
                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
                for (collision = detect(0);
                    collision.Left.Touch && Core.Object.GoingLeft;
                    collision = detect(0))
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
                for (collision = detect(0);
                    collision.Right.Touch && Core.Object.GoingRight;
                    collision = detect(0))
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                collision = detect(0);
                if (collision.TopRight.Touch && collision.TopLeft.None ||
                    collision.Right.Touch && Core.Object.GoingUp)
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
                collision = detect(0);
                if (collision.TopLeft.Touch && collision.TopRight.None ||
                    collision.Left.Touch && Core.Object.GoingUp)
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
            }
        }
    }
}