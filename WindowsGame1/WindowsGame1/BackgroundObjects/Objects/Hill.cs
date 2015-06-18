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

            // make it not solid so that anything can pass through it
            Solid = false;
        }

        protected override void SyncState()
        {

        }

    }
}
