using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Hill : ObjectKernelNew<HillSpriteState, BackgroundMotionState>
    {
        public Hill(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new HillSpriteState();
            MotionState = new BackgroundMotionState(location);

        }
        protected override void SyncState()
        {

        }

    }
}
