using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Bush : ObjectKernel<BushSpriteState, BackgroundMotionState>
    {
        public Bush(WorldManager world) : base(world) { }

        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }

        protected override void Initialize()
        {
            SpriteState = new BushSpriteState();
            MotionState = new BackgroundMotionState();
        }


        protected override void SyncState()
        {

        }

    }
}