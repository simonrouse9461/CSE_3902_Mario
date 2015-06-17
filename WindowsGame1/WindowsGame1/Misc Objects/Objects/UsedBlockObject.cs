using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class UsedBlockObject : ObjectKernelNew<UsedBlockSpriteState, UsedBlockMotionState>
    {
        public UsedBlockObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new UsedBlockSpriteState();
            MotionState = new UsedBlockMotionState(location);
        }
    }
}
