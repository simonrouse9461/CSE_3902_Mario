using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class UsedBlockObject : ObjectKernel<UsedBlockSpriteState, UsedBlockMotionState>
    {
        public UsedBlockObject(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new UsedBlockSpriteState();
            MotionState = new UsedBlockMotionState();
        }

        protected override void SyncState()
        {

        }
    }
}
