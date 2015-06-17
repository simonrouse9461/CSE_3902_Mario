using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Bush : ObjectKernelNew<BushSpriteState, BackgroundMotionState>
    {
        public Bush(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new BushSpriteState();
            MotionState = new BackgroundMotionState(location);

        }

        protected override void SyncState()
        {

        }

    }
}