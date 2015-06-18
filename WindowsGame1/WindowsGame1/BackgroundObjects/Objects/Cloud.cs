using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Cloud : ObjectKernel<CloudSpriteState, BackgroundMotionState>
    {
        public Cloud(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new CloudSpriteState();
            MotionState = new BackgroundMotionState();

            // make it not solid so that anything can pass through it
            Solid = false;
        }
        protected override void SyncState()
        {

        }

    }
}
