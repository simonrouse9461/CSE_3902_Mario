using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{

    public class _1up : ObjectKernelNew<_1upSpriteState, RightMotionState>
    {
        public _1up(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new _1upSpriteState();
            MotionState = new RightMotionState(location);

        }
        protected void Reset()
        {

        }
   }
}
