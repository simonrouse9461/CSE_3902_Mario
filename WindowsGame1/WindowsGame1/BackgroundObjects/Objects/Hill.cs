using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Hill : ObjectKernel<HillSpriteState, BackgroundMotionState>
    {
        public Hill(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new HillSpriteState();
            MotionState = new BackgroundMotionState();

        }
        protected override void SyncState()
        {

        }

    }
}
