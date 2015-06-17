using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class UsedBlockObject : ObjectKernel<UsedBlockSpriteState, UsedBlockMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new UsedBlockSpriteState();
            MotionState = new UsedBlockMotionState();
        }
    }
}
