using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernel<IndestructibleBlockSpriteState, IndestructibleBlockMotionState>
    {

        protected override void Initialize()
        {
            SpriteState = new IndestructibleBlockSpriteState();
            MotionState = new IndestructibleBlockMotionState();
        }
    }

}
