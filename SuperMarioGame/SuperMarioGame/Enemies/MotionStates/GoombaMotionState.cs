using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaMotionState : EnemyMotionStateKernel
    {

        public override void Turn(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Default:
                    if (GoingLeft) GoRight();
                    else GoLeft();
                    break;
                case Orientation.Left:
                    GoLeft();
                    break;
                case Orientation.Right:
                    GoRight();
                    break;
            }
        }

        public override Orientation Orientation
        {
            get
            {
                if (GoingLeft) return Orientation.Left;
                if (GoingRight) return Orientation.Right;
                return Orientation.Default;
            }
        }
    }
}