using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : ObjectKernelNew<NormalBlockSpriteState, NormalBlockMotionState>
    {
        public NormalBlockObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new NormalBlockSpriteState();
            MotionState = new NormalBlockMotionState(location);
        }
    }
}
