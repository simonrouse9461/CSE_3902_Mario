using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernelNew<IndestructibleBlockSpriteState, IndestructibleBlockMotionState>
    {
        public IndestructibleBlockObject(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new IndestructibleBlockSpriteState();
            MotionState = new IndestructibleBlockMotionState();
        }

        protected override void SyncState()
        {

        }
    }

}
