using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : ObjectKernelNew<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {

        public DestructibleBlockObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new DestructibleBlockSpriteState();
            MotionState = new DestructibleBlockMotionState(location);
        }
    }
}
