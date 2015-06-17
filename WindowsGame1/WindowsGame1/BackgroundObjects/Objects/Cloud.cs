using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Cloud : ObjectKernelNew<CloudSpriteState, BackgroundMotionState>
    {
        public Cloud(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new CloudSpriteState();
            MotionState = new BackgroundMotionState(location);

        }
        protected override void SyncState()
        {

        }

    }
}
