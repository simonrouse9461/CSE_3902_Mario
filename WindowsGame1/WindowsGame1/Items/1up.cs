using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{

    public class _1up : ObjectKernelNew<_1upSpriteState, RightMotionState>
    {
        public _1up(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new _1upSpriteState();
            MotionState = new RightMotionState();
        }
        protected override void SyncState()
        {

        }
   }
}
