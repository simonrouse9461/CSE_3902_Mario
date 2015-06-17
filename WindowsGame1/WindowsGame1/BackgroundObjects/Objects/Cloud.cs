using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Cloud : ObjectKernelNew<CloudSpriteState, BackgroundMotionState>
    {
        public Cloud(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new CloudSpriteState();
            MotionState = new BackgroundMotionState();

        }
        protected override void SyncState()
        {

        }

    }
}
