using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernelNew<IndestructibleBlockSpriteState, IndestructibleBlockMotionState>
    {

        public IndestructibleBlockObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new IndestructibleBlockSpriteState();
            MotionState = new IndestructibleBlockMotionState(location);
        }
    }

}
